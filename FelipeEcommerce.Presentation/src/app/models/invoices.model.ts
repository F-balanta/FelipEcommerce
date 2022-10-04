export interface Iinvoices {
  id: number,
  invoiceNumber: string,
  clientId: number,
  userId: number,
  invoiceDate: string,
  total: number,
  subTotal: number
  isv: number,
  discount: number
}

export class invoices {
  id: number = 0;
  invoiceNumber: string = "";
  userId: number = 0;
  invoiceDate: string = "";
  total: number = 0;
  subTotal: number = 0;
  isv: number = 0;
  discount: number = 0;
}
