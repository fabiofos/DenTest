import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { MachineDisplayData } from '../models/machine-display-data-model';

@Injectable({
    providedIn: 'root'
})
export class CalculatorService {
    private _displayData = new BehaviorSubject<MachineDisplayData>({
        canBuy: false,
        balance: 0,
        message: 'O Euros Inserted',
        secondaryMessage: ''
    })

    constructor() { }

    get displayData(): MachineDisplayData {
        return this._displayData.value
    }

    set displayData(displayData: MachineDisplayData) {
        this._displayData.next(displayData)
    }
}