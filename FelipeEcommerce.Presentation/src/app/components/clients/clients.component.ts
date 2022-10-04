import {Component, OnInit} from '@angular/core';
import {Clients, IClient} from '../../models/clients.model';
import {ClientsService} from '../../services/clients/clients.service';
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.scss']
})
export class ClientsComponent implements OnInit {
  _clients: Clients = new Clients();
  datatable: any = [];

  id: number = 0;
  firstName: string = '';
  lastName: string = '';
  phone: string = '';
  dni: string = '';
  address: string = '';
  age: number = 0;

  constructor(
    private clientService: ClientsService,
    public modal: NgbModal
  ) {
  }

  ngOnInit(): void {
    this.onGetAllClients()
  }


  onGetAllClients() {
    this.clientService.getAllClients().subscribe(data => {
      this.datatable = data;
    })
  }

  getDataDelete(select: any) {
    this.id = select.id
    this.firstName = select.firstName;
    this.lastName = select.lastName;
    this.phone = select.phone;
    this.dni = select.dni;
    this.address = select.address;
    this.age = select.age;
    this.onDeleteClient(this._clients, this.id)
  }

  getDataEdit(select: any) {
    this._clients.id = select.id;
    this._clients.firstName = select.firstName;
    this._clients.lastName = select.lastName;
    this._clients.phone = select.phone;
    this._clients.dni = select.dni;
    this._clients.address = select.address;
    this._clients.age = select.age;
  }

  clear() {
    this._clients.id = 0;
    this._clients.firstName = '';
    this._clients.lastName = '';
    this._clients.phone = '';
    this._clients.dni = '';
    this._clients.address = '';
    this._clients.age = 0;
  }

  onUpdateClient(dato: IClient) {
    this.clientService.update(dato.id, dato)
      .subscribe(data => {
        if(data) {
          this.clear();
          this.onGetAllClients();
        }
      })
  }

  onDeleteClient(dato: IClient, id: number) {
    this.clientService.delele(id)
      .subscribe(data => {
        if (data) {
          this.onGetAllClients();
        }
      })
  }
}
