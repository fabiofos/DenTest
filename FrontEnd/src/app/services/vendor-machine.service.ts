import { Injectable } from '@angular/core';  
import { HttpClient, HttpHeaders } from '@angular/common/http';  
import { Observable, throwError, of } from 'rxjs';  
import { catchError, map } from 'rxjs/operators';  
import { environment } from 'src/environments/environment';  
import { Machine } from '../models/machine.model';
import { MachineSlot } from '../models/machine-slots.model';
import { Product } from '../models/product.model';
import { Sale } from '../models/sales.model';

@Injectable({
  providedIn: 'root'
})
export class VendorMachineService {

  private machineUrl = environment.baseUrl + 'vendorMachine/webapi/v1/Machine';  
  private _getMachineEndpoint = 'GetMachineById';  
  private _getSlotsMachineEndpoint = 'GetSlotsMachineById';  
  private _getProductStockEndpoint = 'GetProductStockByProductId';  
  private _createSale = 'CreateSale';  
  private _updateMachine = 'UpdateMachine';  
  private _machineId = 1;
  
  constructor(private http: HttpClient) { }  
  
  GetMachineData(): Observable<Machine> {  
    return this.http.get<Machine>(`${this.machineUrl}/${this._getMachineEndpoint}/${this._machineId}`);  
  }  

  GetSlotsMachineData(machineId: number): Observable<MachineSlot[]> {  
    return this.http.get<MachineSlot[]>(`${this.machineUrl}/${this._getSlotsMachineEndpoint}/${machineId}`);  
  }  

  GetProductStock(productId: number): Observable<Product> {  
    return this.http.get<Product>(`${this.machineUrl}/${this._getProductStockEndpoint}/${productId}`);  
  }  

  CreateSale(sale: Sale): Observable<any> {  
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });  
    return this.http.post<any>(`${this.machineUrl}/${this._createSale}`, sale, { headers: headers })  
      .pipe(  
        catchError(this.handleError)  
      );  
  }  

  UpdateMachine(machine: Machine): Observable<any> {  
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });  
    return this.http.put<any>(`${this.machineUrl}/${this._updateMachine}`, machine, { headers: headers })  
      .pipe(  
        catchError(this.handleError)  
      );  
  }  

  private handleError(err: any) {  
    let errorMessage: string;  
    if (err.error instanceof ErrorEvent) {  
      errorMessage = `An error occurred: ${err.error.message}`;  
    } else {  
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;  
    }  
    console.error(err);  
    return throwError(errorMessage);  
  }  
}