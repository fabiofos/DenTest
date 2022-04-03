import { AfterViewChecked, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { VendorMachineService } from 'src/app/services/vendor-machine.service';
import { faSpinner, faEuroSign, faUndo, faInfo } from '@fortawesome/free-solid-svg-icons'
import { ToastService } from 'src/app/services/toast.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MachineDisplayData } from 'src/app/models/machine-display-data-model';
import { CalculatorService } from 'src/app/services/calculator.service';
import { Sale } from 'src/app/models/sales.model';
import { MachineSlot } from 'src/app/models/machine-slots.model';
import { Product } from 'src/app/models/product.model';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit, AfterViewChecked {
  machineData: any;
  machineSlotsData: MachineSlot[] = [];
  sales: Sale[] = [];
  selectedProduct!: Product;
  errorMessage = '';
  totalMoney = 0;

  public dashboardForm!: FormGroup;
  public displayData!: MachineDisplayData;

  /** Icons */
  faSpinner = faSpinner;
  faEuroSign = faEuroSign;
  faUndo = faUndo;
  faInfo = faInfo;

  constructor(private vendorMachineService: VendorMachineService,
    private toastService: ToastService,
    private _formBuilder: FormBuilder,
    private _calculatorService: CalculatorService,
    private cdr: ChangeDetectorRef) {

  }

  ngOnInit(): void {
    this.dashboardForm = this._formBuilder.group({
      display: [{ value: "Insert Your Coin" }]
    })

    this.GetMachineData();
    this.GetSales();
  }

  ngAfterViewChecked() {
    this.cdr.detectChanges();
  }

  GetMachineData() {
    this.vendorMachineService.GetMachineData().subscribe(
      resp => {
        this.machineData = resp;
        this.dashboardForm.get('display')?.patchValue("Insert Coin");
        if (resp.id) {
          this.GetMachineSlotsData(resp.id);
        }

      },
      error => this.errorMessage = <any>error
    );
  }

  GetSales() {
    this.vendorMachineService.GetSales().subscribe(
      resp => {
        this.sales = resp;

        this.totalMoney = this.sales.map(a => a.productPrice).reduce(function (a, b) {
          return a + b;
        });
      },
      error => this.errorMessage = <any>error
    );
  }

  AddCoin(value: number) {
    this._calculatorService.displayData.balance += value;
    this._calculatorService.displayData.message = `Amount Entered ${this._calculatorService.displayData.balance.toFixed(2)}`;
    this.dashboardForm.get('display')?.patchValue(this._calculatorService.displayData.message);
    this._calculatorService.displayData.secondaryMessage = `Coin ${value.toFixed(2)} just added`;
    this.machineSlotsData.forEach(item => {
      if (item.product != null)
        item.product.remainingAmount = item.product.price - this._calculatorService.displayData.balance > 0 ? Number((item.product.price - this._calculatorService.displayData.balance).toFixed(2)) : 0;
    }
    );
  }

  DisableSelection(slot: any) {
    if (slot.product.remainingAmount == undefined)
      return true;
    if (slot.product) {
      var disable = slot.product.productStock.quantity <= 0 || slot.product.remainingAmount != 0;
      this._calculatorService.displayData.canBuy = disable;
      return disable;
    }
    return true;
  }

  ResetBalance() {
    this._calculatorService.displayData.balance = 0;
    this._calculatorService.displayData.message = `Insert Coin`;
    this._calculatorService.displayData.secondaryMessage = `Thanks - Please take your coins at the Tray`;
    this.dashboardForm.get('display')?.patchValue(this._calculatorService.displayData.message);

    this.machineSlotsData.forEach(item => {
      if (item.product != null)
        item.product.remainingAmount = item.product.price;
    }
    );
  }

  SetProduct(product: any) {
    this.selectedProduct = product;
  }

  GetMachineSlotsData(machineId: number) {
    this.vendorMachineService.GetSlotsMachineData(machineId).subscribe(
      resp => {
        this.machineSlotsData = resp;
      },
      error => this.errorMessage = <any>error
    );
  }

  CreateSale() {
    if (!this.selectedProduct)
      return;

    var sale = {
      productId: this.selectedProduct.id,
      productPrice: this.selectedProduct.price,
      createdOn: new Date
    };

    this.vendorMachineService.CreateSale(sale).subscribe(
      success => {
        var change = this._calculatorService.displayData.balance - sale.productPrice;
 
        this._calculatorService.displayData.message = `Insert Coin`;
        this._calculatorService.displayData.secondaryMessage = change <= 0 ? `Thank you for Buying - See you!!` : `Thank you for Buying, take your change ${change.toFixed(2)} at the tray - See you!!`;
        this.toastService.showSuccessMessage(`Sale completed`)
        this.GetMachineData();
        this.GetSales();
      },
      err => this.toastService.showErrorMessage(err.message)
    )
  }

  get secondaryMessage(): string {
    return this._calculatorService.displayData.secondaryMessage
  }

  get canBuy(): boolean {
    return this._calculatorService.displayData.canBuy
  }

  get canReturnCoins(): boolean {
    return this._calculatorService.displayData.balance > 0
  }
}
