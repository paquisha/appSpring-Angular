import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { formatDate } from '@angular/common';
import { Observable, catchError, throwError } from 'rxjs';
import { map, tap } from 'rxjs/operators'
import { Cliente } from '../clientes/cliente';
import swal from 'sweetalert2';
import { ActivatedRoute, Router } from '@angular/router';
import { ClientesComponent } from '../clientes/clientes.component';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  BACK_SPRING = 'http://Localhost:8080/api/clientes';

  httpHeader = new HttpHeaders({'Content-Type' : 'application/json'});

  constructor(private _rest: HttpClient,
    private _router: Router,
    private _activateRoute: ActivatedRoute) { }

  public findAll(): Observable<any>{
    return this._rest.get<Cliente[]>(this.BACK_SPRING).pipe(tap( (response: any ) =>{
      (response.content as Cliente[]).forEach(cliente => {
        console.log(cliente.nombre);
      });
      }),
      map( (response: any) => {
        (response.content as Cliente[]).map(cliente => {
          cliente.nombre = cliente.nombre.toUpperCase();
          cliente.apellido = cliente.apellido.toUpperCase();
          cliente.createAt = formatDate(cliente.createAt, 'dd-MM-yyyy', 'en-US')
          return cliente;
      });
      return response;
      }),
      tap(response => {
        (response.content as Cliente[]).forEach(cliente =>{
          console.log(cliente.nombre);
        });
      })
    );
  }

  public create(cliente: Cliente): Observable<any> {
    return this._rest.post<Cliente>(this.BACK_SPRING, cliente, {headers: this.httpHeader} ).pipe(
      catchError(e => {

        if(e.status==400){
          return throwError(e);
        }

        swal.fire({
          icon: 'error',
          title: 'Error al Crear',
          text: `error ${e.error.error}`
        })
        return throwError(e);
      })
    )
  }

  public getCliente(id: number): Observable<Cliente>{
    return this._rest.get<Cliente>(`${this.BACK_SPRING}/${id}`).pipe(
      catchError(e => {
        this._router.navigate(['/clientes']);
        console.log(e.error);
        swal.fire({
          icon: 'error',
          title: 'Error al consultar',
          text: `error ${e.error.mensaje}`
        })
        return throwError(e);
      })
    )
  }

  public update(cliente: Cliente): Observable<Cliente>{
    return this._rest.put<Cliente>(`${this.BACK_SPRING}/${cliente.id}`, cliente, {headers: this.httpHeader}).pipe(
      catchError(e => {

        if(e.status==400){
          return throwError(e);
        }


        swal.fire({
          icon: 'error',
          title: 'Error al editar',
          text: `error ${e.error.error}`
        })
        return throwError(e);
      })
    )
  }

  public delete(id: number): Observable<Cliente>{
    return this._rest.delete<Cliente>(`${this.BACK_SPRING}/${id}`, {headers: this.httpHeader}).pipe(
      catchError(e => {
        swal.fire({
          icon: 'error',
          title: 'Error al eliminar',
          text: `error ${e.error.error}`
        })
        return throwError(e);
      })
    )
  }
}
