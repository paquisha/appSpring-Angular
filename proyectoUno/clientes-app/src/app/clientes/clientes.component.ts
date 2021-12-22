import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../services/cliente.service';
import { Clientes } from './cliente';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {

  clientes: Clientes[] = [];


  constructor(private _clientesService: ClienteService) { }

  ngOnInit(): void {
    this.init();
  }

  init(){
    this._clientesService.findAll().subscribe(data => {
      if(data){
        this.clientes = data;
        console.log(this.clientes);
      }
    });
  }

}
