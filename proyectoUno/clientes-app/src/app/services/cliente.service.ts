import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Clientes } from '../clientes/cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  BACK_SPRING = 'http://Localhost:8080/api/clientes';

  constructor(private _rest: HttpClient) { }

  public findAll(): Observable<Clientes[]>{
    return this._rest.get<Clientes[]>(this.BACK_SPRING);
  }
}
