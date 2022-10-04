import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import {IProduct, Product} from "../../models/products.model";
import {ICreateProductDTO, IUpdateProductDTO} from "../../models/DTOs/productDTO";

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  apiUrl:string = 'https://localhost:5001/api/products'
  constructor(
    private http: HttpClient
  ) { }

  getProducts(){
    return this.http.get<IProduct[]>(`${this.apiUrl}`);
  }

  getProduct(id:number){
    return this.http.get<IProduct>(`${this.apiUrl}/${id}`)
  }
  createProduct(dtoCreate: ICreateProductDTO){
    return this.http.post<IProduct>(`${this.apiUrl}`,dtoCreate);
  }

  updateProduct(id:number, dtoUpdate:Product){
    return this.http.put<IProduct>(`${this.apiUrl}/${id}`,dtoUpdate);
  }

  deleteProduct(id:number){
    return this.http.delete<boolean>(`${this.apiUrl}/${id}`);
  }
}
