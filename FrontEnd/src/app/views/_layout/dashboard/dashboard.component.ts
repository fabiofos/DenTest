import { Component, OnInit } from '@angular/core';
import { VendorMachineService } from 'src/app/services/vendor-machine.service';
import { faSpinner, faTasks } from '@fortawesome/free-solid-svg-icons'
import { ToastService } from 'src/app/services/toast.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  machineData: any;
  errorMessage = '';
  /** Icons */
  faSpinner = faSpinner;
  faTasks = faTasks;

  constructor(private vendorMachineService: VendorMachineService,
    private toastService: ToastService,
    private datePipe: DatePipe) { }

  ngOnInit(): void {
    this.GetMachineData();
  }

  GetMachineData() {
    this.vendorMachineService.GetMachineData().subscribe(
      resp => {
        this.machineData = resp;
        console.log('machine data', resp);
        
      },
      error => this.errorMessage = <any>error
    );
  }

  CreateSale(event: any) {
    if (!event.data)
      return;

      var sale = event.data;

    this.vendorMachineService.CreateSale(sale).subscribe(
      success => {
        console.log(success)
        this.toastService.showSuccessMessage(`Sale completed : ${sale.name}`)
        this.GetMachineData();
      },
      err => this.toastService.showErrorMessage(err.message)
    )
  }
}
