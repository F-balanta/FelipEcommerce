import { Component, OnInit } from '@angular/core';
import {ClientsService} from "../../services/clients/clients.service";
import {clientCreateDto} from "../../models/DTOs/clientDTO";
import {Router} from '@angular/router';

@Component({
  selector: 'app-create-client',
  templateUrl: './create-client.component.html',
  styleUrls: ['./create-client.component.scss']
})
export class CreateClientComponent implements OnInit {
  clients:clientCreateDto[] = [];

  newClient: clientCreateDto = {
    firstName: '',
    lastName: '',
    address: '',
    dni: '',
    age: 0,
    phone: ''};

  constructor(
    private clientService: ClientsService,
    private routes:Router
  ) { }

  ngOnInit(): void {
  }
  clear(){
    this.newClient.firstName ="";
    this.newClient.lastName ="";
    this.newClient.address ="";
    this.newClient.dni ="";
    this.newClient.phone ="";
    this.newClient.age = 0;
  }

  getdataForm(select:any){
    this.newClient.firstName = select.firsName;
    this.newClient.lastName = select.lastName;
    this.newClient.address = select.address;
    this.newClient.dni = select.dni;
    this.newClient.phone = select.phone;
    this.newClient.age = select.age;
    this.onCreate(this.newClient);
  }


  onCreate(client:clientCreateDto){
    this.clientService.create(client)
      .subscribe(data =>{
        this.clients.unshift(data);
        this.routes.navigate(['clients']);

      });
  }
}
