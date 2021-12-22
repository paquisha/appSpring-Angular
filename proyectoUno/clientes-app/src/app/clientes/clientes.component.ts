import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../services/cliente.service';
import { Clientes } from './cliente';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {

  clientes: Clientes[] = [
    {id: 1, nombre: 'Andres', apellido: 'Grijalva', email: 'mail@mail.com', createAt: '2021-12-21'},
    {id: 2, nombre: 'Gina', apellido: 'Pachacama', email: 'mail1@mail.com', createAt: '2021-12-21'},
    {id: 3, nombre: 'Natalia', apellido: 'Grijalva', email: 'mail2@mail.com', createAt: '2021-12-21'}, 
    {id: 4, nombre: 'Maria', apellido: 'banda', email: 'mail3@mail.com', createAt: '2021-12-21'}, 
    {id: 5, nombre: 'Evelyn', apellido: 'Benavides', email: 'mail4@mail.com', createAt: '2021-12-21'}, 
    {id: 6, nombre: 'Grace', apellido: 'Chen', email: 'mail5@mail.com', createAt: '2021-12-21'}     
  ];


  constructor(private _clientesService: ClienteService) { }

  ngOnInit(): void {
  }

}
