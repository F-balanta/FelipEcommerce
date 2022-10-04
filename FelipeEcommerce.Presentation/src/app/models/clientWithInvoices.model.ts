import {Clients, IClient} from "./clients.model";
import {Iinvoices, invoices} from "./invoices.model";

export interface IClientWithInvoices extends IClient{
  invoices: Iinvoices[]
}

export class ClientWithInvoices{
  id: number = 0;
  firstName: string = '';
  lastName: string = '';
  phone: string = '';
  dni: string = '';
  address: string = '';
  age: number = 0;
}
