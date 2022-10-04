import { NgModule } from '@angular/core';

import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from './components/home/home.component';
import {CreateProductComponent} from './components/create-product/create-product.component';
import {ClientsComponent} from './components/clients/clients.component';
import {InvoicesComponent} from './components/invoices/invoices.component';
import {UsersComponent} from './components/users/users.component';
import {InventoryComponent} from "./components/inventory/inventory.component";
import {CreateClientComponent} from "./components/create-client/create-client.component";
import {ClientWithInvoicesComponent} from "./components/client-with-invoices/client-with-invoices.component";
import * as path from "path";
import { CreateInvoiceClientComponent } from './components/create-invoice-client/create-invoice-client.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'createProduct', component: CreateProductComponent},
  {path: 'clients', component: ClientsComponent},
  {path: 'createClient', component: CreateClientComponent},
  {path: 'clients/:id', component: ClientWithInvoicesComponent},
  {path: 'createInvoiceClient/:id', component: CreateInvoiceClientComponent},
  {path: 'invoices', component: InvoicesComponent},
  {path: 'inventory', component: InventoryComponent},
  {path: 'users', component: UsersComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
