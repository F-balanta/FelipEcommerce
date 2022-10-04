import {Component, OnInit} from '@angular/core';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {IProduct, Product} from '../../models/products.model';
import {StoreService} from '../../services/store/store.service';
import {ProductsService} from '../../services/products/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  myShoppingCart: IProduct[] = [];
  total = 0;
  products: IProduct[] = [];
  product: Product = new Product();
  showProductDetail = false;
  productChosen: IProduct = {
    id: 0,
    name: '',
    price: 0,
    urlImage: '',
    description: ''
  }

  constructor(
    private storeService: StoreService,
    private productsService: ProductsService,
    public modal: NgbModal
  ) {
    this.myShoppingCart = this.storeService.getShoppingCart();
  }

  ngOnInit(): void {
    this.getAllProducts();
  }

  getAllProducts() {
    this.productsService.getProducts()
      .subscribe(data => {
        this.products = data;
      });
  }

  onAddToShoppingCart(product: IProduct) {
    this.storeService.addProduct(product);
    this.total = this.storeService.getTotal();
  }


  toggleProductDetail() {
    this.showProductDetail = !this.showProductDetail;
  }

  onShowDetail(id: number) {
    this.productsService.getProduct(id)
      .subscribe(data => {
        this.toggleProductDetail()
        this.productChosen = data;
      })
  }

  onUpdateProduct(select: any) {
    this.product.name = select.name;
    this.product.description = select.description;
    this.product.urlImage = select.urlImage;
    this.product.price = select.price;

    const id: number = this.productChosen.id;
    this.productsService.updateProduct(id, this.product)
      .subscribe(data => {
        const productIndex = this.products.findIndex(x => x.id === this.productChosen.id);

        this.products[productIndex] = data;
        this.productChosen = data;
        this.showProductDetail = false;
      });
  }

  onDeleteProduct() {
    const id = this.productChosen.id;
    this.productsService.deleteProduct(id)
      .subscribe(() => {
        const index = this.products.findIndex(data => data.id === this.productChosen.id);
        this.products.splice(index, 1)
        // Cierra el modal al eliminar el producto
        this.showProductDetail = false;
      })
  }

}
