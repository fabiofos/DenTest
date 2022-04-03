import { ProductStock } from "./product-stock.model.ts"

export interface Product {  
    id: number,  
    name: string,  
    description: string
    price: number
    remainingAmount: number
    createdOn: string
    productStock: ProductStock
}   