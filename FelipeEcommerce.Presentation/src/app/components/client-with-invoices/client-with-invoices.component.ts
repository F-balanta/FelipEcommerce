import { Component, OnInit } from '@angular/core';
import {Router,  ActivatedRoute} from '@angular/router'
import {ClientsService} from '../../services/clients/clients.service'
import {IClientWithInvoices} from "../../models/clientWithInvoices.model";

@Component({
  selector: 'app-client-with-invoices',
  templateUrl: './client-with-invoices.component.html',
  styleUrls: ['./client-with-invoices.component.scss']
})
export class ClientWithInvoicesComponent implements OnInit {
  clients :any = [];
  cInvoices:any = [];
  receivedId:any;

  constructor(
    private router: Router,
    private route :ActivatedRoute,
    private clientService: ClientsService
  ){}

  ngOnInit(): void {
    this.receivedId = this.route.snapshot.paramMap.get('id');
    this.onGetClient();
  }

  onGetClient(){
    this.clientService.getClient(this.receivedId)
      .subscribe((resp:IClientWithInvoices)  =>{
        this.clients = resp;

        this.cInvoices = resp.invoices;
        console.log(resp.invoices[0].invoiceNumber);
      })
  }
  onUpdateInvoice(){}
  onDeleteInvoice(){}
}
