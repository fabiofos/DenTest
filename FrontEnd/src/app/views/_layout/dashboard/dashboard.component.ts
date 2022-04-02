import { Component, OnInit } from '@angular/core';
import { VendorMachineService } from 'src/app/services/vendor-machine.service';
import { faSpinner, faEuroSign, faUndo  } from '@fortawesome/free-solid-svg-icons'
import { ToastService } from 'src/app/services/toast.service';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  machineData: any;
  machineSlotsData: any;
  errorMessage = '';
  
  public dashboardForm!: FormGroup;

  /** Icons */
  faSpinner = faSpinner;
  faEuroSign = faEuroSign;
  faUndo = faUndo;

  constructor(private vendorMachineService: VendorMachineService,
    private toastService: ToastService,
    private _formBuilder: FormBuilder) {

     }

  ngOnInit(): void {
    this.dashboardForm = this._formBuilder.group({
      display: [{value: "Insert Your Coin"}]
    })

    this.GetMachineData();
  }

  GetMachineData() {
    this.vendorMachineService.GetMachineData().subscribe(
      resp => {
        this.machineData = resp;
        console.log('machine data', resp);
        this.dashboardForm.get('display')?.patchValue("Insert Coin");
        if (resp.id){
          this.GetMachineSlotsData(resp.id);
        }
        
      },
      error => this.errorMessage = <any>error
    );
  }

  SetProduct(product: any){
    console.log('escolher produto', product);
  }

  GetMachineSlotsData(machineId: number) {
    this.vendorMachineService.GetSlotsMachineData(machineId).subscribe(
      resp => {
        this.machineSlotsData = resp;
        console.log('machine slot data', resp);
        
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
