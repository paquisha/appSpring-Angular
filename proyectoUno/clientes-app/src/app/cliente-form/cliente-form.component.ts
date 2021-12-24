import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Cliente } from '../clientes/cliente';
import { ClienteService } from '../services/cliente.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-cliente-form',
  templateUrl: './cliente-form.component.html',
  styleUrls: ['./cliente-form.component.css']
})
export class ClienteFormComponent implements OnInit {

  @Input() id: number;

  cliente: Cliente = new Cliente();
  title: string = 'Crear Cliente';

  constructor(private _clientesService: ClienteService,
    private _router: Router,
    private _activateRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.cargarCliente();
  }

  save(): void{
    this._clientesService.create(this.cliente).subscribe(json => {
      this._router.navigate(['/clientes'])
      swal.fire({
        icon: 'success',
        title: 'nuevo cliente',
        text: `cliente creado con exito ${json.cliente.nombre} ${json.cliente.apellido}`
      })
    })    
  }

  update(): void{
    this._clientesService.update(this.cliente).subscribe( data => {
      this._router.navigate(['/clientes'])
      swal.fire({
        icon: 'success',
        title: 'Cliente Actualizado',
        text: `cliente actualizado con exito ${data.nombre} ${data.apellido}`
      })
    })
  }

  cargarCliente(): void{
    this._activateRoute.params.subscribe(params =>{
      let id = params['id'];
      if(id){
        this.init(id);
      }
    })
  }

  init(id: number){
    this._clientesService.getCliente(id).subscribe( data => {
      if(data){
        this.cliente = data;
        console.log(this.cliente);
      }
    })
  }

}
