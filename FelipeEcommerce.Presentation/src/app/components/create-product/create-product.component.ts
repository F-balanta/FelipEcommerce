import { Component, OnInit } from '@angular/core';
import {ProductsService} from '../../services/products/products.service';
import {ICreateProductDTO} from "../../models/DTOs/productDTO";

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.scss']
})
export class CreateProductComponent implements OnInit {
  products:ICreateProductDTO[] = [];
  newProduct: ICreateProductDTO = {
    name : '',
    description: '',
    urlImage: '',
    price: 0
  };


  constructor(
    private producstervice: ProductsService
  )
  { }


  ngOnInit(): void {
  }
  clearForm(){
    this.newProduct.name = "";
    this.newProduct.description = "";
    this.newProduct.urlImage = "";
    this.newProduct.price = 0;
  }

  getdataForm(select:any){
    this.newProduct.name = select.name;
    this.newProduct.description = select.description;
    this.newProduct.urlImage = select.urlImage;
    this.newProduct.price = select.price;
    this.onCreateNewProduct(this.newProduct);
  }

  onCreateNewProduct(product:ICreateProductDTO) {
  this.producstervice.createProduct(product)
    .subscribe(data =>{
      this.products.unshift(data);
    })
  }


}
