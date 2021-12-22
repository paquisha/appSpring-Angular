import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../services/cliente.service';
import { Cliente } from './cliente';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {

  clientes: Cliente[] = [];


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

  editar(id: number){
    console.log(id);
  }

  ver(id: number){

  }

  borrar(id: number){
    
  }
}
