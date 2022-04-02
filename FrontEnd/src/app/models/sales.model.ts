import { Product } from "./product.model";

export interface Sale {  
    id: number,  
    productId: number,  
    productPrice: number,  
    createdOn: string,  
    product: Product
}   