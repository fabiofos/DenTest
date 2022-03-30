import { Component, OnInit, ViewChild } from '@angular/core';
import { Product } from 'src/app/models/products.model';
import { ProductsService } from 'src/app/services/products.service';
import * as signalR from '@microsoft/signalr';
import { environment } from 'src/environments/environment';
import { DxDataGridComponent } from 'devextreme-angular';
import DataSource from 'devextreme/data/data_source';
import { faSpinner, faTasks } from '@fortawesome/free-solid-svg-icons'
import { ToastService } from 'src/app/services/toast.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  pageTitle = 'Products List';
  filteredProducts: Product[] = [];
  products: Product[] = [];
  errorMessage = '';
  /** Icons */
  faSpinner = faSpinner;
  faTasks = faTasks;

  /** Grid Configuration */
  @ViewChild(DxDataGridComponent, { static: false }) dataGridComponent: DxDataGridComponent | undefined;
  gridDataSource!: DataSource;

  constructor(private productsService: ProductsService,
    private toastService: ToastService,
    private datePipe: DatePipe) { }

  _listFilter = '';
  get listFilter(): string {
    return this._listFilter;
  }

  set listFilter(value: string) {
    this._listFilter = value;
    this.filteredProducts = this.listFilter ? this.performFilter(this.listFilter) : this.products;
  }

  performFilter(filterBy: string): Product[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.products.filter((produtos: Product) =>
      produtos.name.toLocaleLowerCase().indexOf(filterBy) !== -1);
  }

  ngOnInit(): void {
    this.getProducts();

    const connection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Information)
      .withUrl(environment.baseUrl + 'notify')
      .build();

    connection.start().then(function () {
      console.log('SignalR Connected!');
    }).catch(function (err) {
      return console.error(err.toString());
    });

    connection.on("BroadcastMessage", () => {
      this.getProducts();
    });
  }

  getProducts() {
    this.productsService.getProducts().subscribe(
      prods => {
        this.products = prods;
        this.filteredProducts = this.products;

        this.gridDataSource = new DataSource({
          store: {
            type: 'array',
            key: 'id',
            data: this.filteredProducts
          }
        });
        this.gridDataSource.requireTotalCount(true)

      },
      error => this.errorMessage = <any>error
    );
  }

  /** Add new material to database/excel file */
  CreateProducts(event: any) {
    if (!event.data)
      return;

    var productObject = this.productsService.initializeProduct();

    productObject = event.data;
    productObject.id = 0;
    productObject.createdOn = this.datePipe.transform(new Date(), 'yyyy-MM-dd') + 'T00:00:01';

    this.productsService.createProduct(productObject).subscribe(
      success => {
        console.log(success)
        this.toastService.showSuccessMessage(`Product successfully added : ${productObject.name}`)
        this.getProducts();
      },
      err => this.toastService.showErrorMessage(err.message)
    )
  }

  /** Update products on database/file */
  UpdateProducts(event: any) {
    if (!event.data)
      return;
    event.data.createdOn = this.datePipe.transform(new Date(), 'yyyy-MM-dd');
   
    this.productsService.updateProduct(event.data).subscribe(
      success => {
        this.toastService.showSuccessMessage(`Product successfully changed : ${event.data.name}`)
        this.getProducts();
      },
      err => this.toastService.showErrorMessage(err.message),
      () => console.log('ok')
    )
  }
}
