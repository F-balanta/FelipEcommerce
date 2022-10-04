import {Iinvoices, invoices} from "./invoices.model";

export interface IClient {
  id: number;
  firstName: string,
  lastName: string,
  phone: string,
  dni: string,
  address: string,
  age: number
}

export class Clients {
  id: number = 0;
  firstName: string = '';
  lastName: string = '';
  phone: string = '';
  dni: string = '';
  address: string = '';
  age: number = 0
}
