import { Machine } from "./machine.model"
import { Product } from "./product.model"

export interface MachineSlot {  
    id: number,  
    productId: number,  
    machineId: number,  
    slotName: string,  
    createdOn: string
    product: Product
    machine: Machine
}   