import { MachineCurrency } from "./machine-currency.model";
import { MachineLanguage } from "./machine-language.model";

export interface Machine {  
    id: number,  
    machineCurrencyId: number,  
    machineLanguageId: number,  
    createdOn: string,  
    maintenanceRequested: boolean,
    machineCurrency: MachineCurrency,
    machineLanguage: MachineLanguage
}   