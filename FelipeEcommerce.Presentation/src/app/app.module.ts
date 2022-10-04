import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {AppRoutingModule} from './app-routing.module';

import {AppComponent} from './app.component';
import {ImgComponent} from './components/img/img.component';
import {ProductComponent} from './components/product/product.component';
import {ProductsComponent} from './components/products/products.component';
import {NavComponent} from './components/nav/nav.component';
import { CreateProductComponent } from './components/create-product/create-product.component';
import { HomeComponent } from './components/home/home.component';
import { UsersComponent } from './components/users/users.component';
import { InvoicesComponent } from './components/invoices/invoices.component';
import { ClientsComponent } from './components/clients/clients.component';
import { InventoryComponent } from './components/inventory/inventory.component';
import { CreateClientComponent } from './components/create-client/create-client.component';
import { ClientWithInvoicesComponent } from './components/client-with-invoices/client-with-invoices.component';
import { CreateInvoiceClientComponent } from './components/create-invoice-client/create-invoice-client.component';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    ProductComponent,
    ProductsComponent,
    ImgComponent,
    CreateProductComponent,
    HomeComponent,
    UsersComponent,
    InvoicesComponent,
    ClientsComponent,
    InventoryComponent,
    CreateClientComponent,
    ClientWithInvoicesComponent,
    CreateInvoiceClientComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {

}
