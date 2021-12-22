import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../clientes/cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  BACK_SPRING = 'http://Localhost:8080/api/clientes';

  constructor(private _rest: HttpClient) { }

  public findAll(): Observable<Cliente[]>{
    return this._rest.get<Cliente[]>(this.BACK_SPRING);
  }

  public update(id: number){
    return this._rest.put<any>(this.BACK_SPRING, { id });
  }

  /*public delete(id: number){
    return this._rest.delete<any>(this.BACK_SPRING, { id })
  }*/
}
