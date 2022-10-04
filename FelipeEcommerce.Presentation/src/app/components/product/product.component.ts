import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { IProduct } from '../../models/products.model';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent {

  @Input() product: IProduct = {
    id: 0,
    name: '',
    price: 0,
    urlImage: '',
    description: ''
  };
  @Output() addedProduct = new EventEmitter<IProduct>();
  @Output() showProduct = new EventEmitter<number>();

  constructor() { }

  onAddToCart() {
    this.addedProduct.emit(this.product);
  }
  onShowDetail(){
    this.showProduct.emit(this.product.id)
  }
}
