import { Component, Input, OnInit } from '@angular/core';
import { Cliente } from '../clientes/cliente';
import { ClienteService } from '../services/cliente.service';

@Component({
  selector: 'app-cliente-form',
  templateUrl: './cliente-form.component.html',
  styleUrls: ['./cliente-form.component.css']
})
export class ClienteFormComponent implements OnInit {

  @Input() id: number;

  cliente: Cliente = new Cliente();
  title: string = 'Crear Cliente';

  constructor(private _clientesService: ClienteService) { }

  ngOnInit(): void {
    this.init(this.id);
  }

  save(){
    console.log(this.cliente);
  }

  init(id: number){
    this._clientesService.update(id).subscribe( data => {
      if(data){
        this.cliente = data;
        console.log(this.cliente);
      }
    })
  }

}
