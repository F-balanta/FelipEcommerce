import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import {Clients, IClient} from "../../models/clients.model";
import {clientCreateDto} from "../../models/DTOs/clientDTO";
import {IClientWithInvoices} from "../../models/clientWithInvoices.model";
@Injectable({
  providedIn: 'root'
})
export class ClientsService {
  apiUrl = 'https://localhost:5001/api/clients';

  constructor(
    private http:HttpClient) {

  }


  getAllClients(){
    return this.http.get<IClient[]>(`${this.apiUrl}`);
  }
  getClient(id:number){
    return this.http.get<IClientWithInvoices>(`${this.apiUrl}/${id}`);
  }
  create(dto:clientCreateDto){
    return this.http.post<IClient>(`${this.apiUrl}`,dto);
  }
  update(id:number,client:Clients){
    return this.http.put<IClient>(`${this.apiUrl}`+`/${id}`,client);
  }
  delele(id:number){
    return this.http.delete<boolean>(`${this.apiUrl}/${id}`);
  }
}

