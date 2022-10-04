import {Iinvoices} from "../invoices.model";

export interface ICreateInvoiceDTO extends Omit<Iinvoices, 'invoiceNumber'|'id'|'total'|'subTotal'>{

}
