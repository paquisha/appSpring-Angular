import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../clientes/cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  BACK_SPRING = 'http://Localhost:8080/api/clientes';

  httpHeader = new HttpHeaders({'Content-Type' : 'application/json'});

  constructor(private _rest: HttpClient) { }

  public findAll(): Observable<Cliente[]>{
    return this._rest.get<Cliente[]>(this.BACK_SPRING);
  }

  public create(cliente: Cliente): Observable<Cliente> {
    return this._rest.post<Cliente>(this.BACK_SPRING, cliente, {headers: this.httpHeader} );
  }

  public getCliente(id: number): Observable<Cliente>{
    return this._rest.get<Cliente>(`${this.BACK_SPRING}/${id}`);
  }

  public update(cliente: Cliente): Observable<Cliente>{
    return this._rest.put<Cliente>(`${this.BACK_SPRING}/${cliente.id}`, cliente, {headers: this.httpHeader});
  }

  public delete(id: number): Observable<Cliente>{
    return this._rest.delete<Cliente>(`${this.BACK_SPRING}/${id}`, {headers: this.httpHeader});
  }
}
