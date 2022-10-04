import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import {Iinvoices} from '../../models/invoices.model'
import {ICreateInvoiceDTO} from '../../models/DTOs/invoicesDTO'
@Injectable({
  providedIn: 'root'
})
export class InvoicesService {
  apiUrl:string = 'https://localhost:5001/api/invoices';
  constructor(
    private http: HttpClient
  ) { }

  getAllInvoices(){
    return this.http.get<Iinvoices>(``)
  }
}
