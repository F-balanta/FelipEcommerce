import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {Iinvoices} from "../../models/invoices.model";
import {ClientsService} from '../../services/clients/clients.service';
import {ICreateInvoiceDTO} from "../../models/DTOs/invoicesDTO";

@Component({
  selector: 'app-create-invoice-client',
  templateUrl: './create-invoice-client.component.html',
  styleUrls: ['./create-invoice-client.component.scss']
})
export class CreateInvoiceClientComponent implements OnInit {

  receivedId:any;
  newInvoice:ICreateInvoiceDTO = {
    clientId: 0,
    invoiceDate: '' ,
    userId: 0,
    isv: 0,
    discount: 0
  };
  invoices: Iinvoices[] = [];

  constructor(
    private router:Router,
    private route: ActivatedRoute,
    private invoiceService: ClientsService
  ) { }

  ngOnInit(): void {
    this.receivedId = this.route.snapshot.paramMap.get('id');
  }

  getDataForm(select:any){
    this.newInvoice.clientId = this.receivedId;
    this.newInvoice.invoiceDate = select.invoiceDate;
    this.newInvoice.userId = select.userId;
    this.newInvoice.isv = select.isv ;
    this.newInvoice.discount = select.discount ;
    console.log(this.newInvoice);
  }
  onCreateInvoiceClient(){

    this.invoiceService.createInvoiceClient()
  }

}
