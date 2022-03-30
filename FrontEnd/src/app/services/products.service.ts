import { Injectable } from '@angular/core';  
import { HttpClient, HttpHeaders } from '@angular/common/http';  
import { Observable, throwError, of } from 'rxjs';  
import { catchError, map } from 'rxjs/operators';  
import { environment } from 'src/environments/environment';  
import { Product } from '../models/products.model';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private ProductsUrl = environment.baseUrl + 'signalr/webapi/v1/Product';  
  
  constructor(private http: HttpClient) { }  
  
  getProducts(): Observable<Product[]> {  
    return this.http.get<Product[]>(`${this.ProductsUrl}/GetProducts`);  
  }  
  
  getProduct(id: string): Observable<Product> {  
    if (id === '') {  
      return of(this.initializeProduct());  
    }  
    const url = `${this.ProductsUrl}/GetProductById/${id}`;  
    return this.http.get<Product>(url);  
  }  
  
  createProduct(Product: Product): Observable<Product> {  
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });  
    return this.http.post<Product>(`${this.ProductsUrl}/CreateProduct`, Product, { headers: headers })  
      .pipe(  
        catchError(this.handleError)  
      );  
  }  
  
  updateProduct(Product: Product): Observable<Product> {  
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });  
    return this.http.put<Product>(`${this.ProductsUrl}/UpdateProduct`, Product, { headers: headers })  
      .pipe(  
        map(() => Product),  
        catchError(this.handleError)  
      );  
  }  

  readFileLines(): Observable<Product[]> {  
    return this.http.get<Product[]>(`${this.ProductsUrl}/GetFileLines`)  
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
  
  public initializeProduct(): Product {  
    return {  
      id: 0,  
      name: "",  
      description: "",  
      price: 0,  
      quantity: 0,  
      createdOn: new Date().toDateString()  
    };  
  }  
}
