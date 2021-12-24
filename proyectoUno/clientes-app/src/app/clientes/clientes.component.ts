import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClienteService } from '../services/cliente.service';
import { Cliente } from './cliente';
import swal from 'sweetalert2';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {

  clientes: Cliente[] = [];


  constructor(private _clientesService: ClienteService,
    private _router: Router,
    private _activateRoute: ActivatedRoute) { }

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


  delete(cliente: Cliente){
    const swalWithBootstrapButtons = Swal.mixin({
      customClass: {
        confirmButton: 'btn btn-success',
        cancelButton: 'btn btn-danger'
      },
      buttonsStyling: false
    })
    
    swalWithBootstrapButtons.fire({
      title: 'Estas Seguro?',
      text: `Seguro desea elminar uusario! ${cliente.nombre} ${cliente.apellido}`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Si',
      cancelButtonText: 'No',
      reverseButtons: true
    }).then((result) => {
      if (result.isConfirmed) {
        this._clientesService.delete(cliente.id).subscribe(data => {
          this.clientes = this.clientes.filter(cli => cli !== cliente)
          swalWithBootstrapButtons.fire(
            'Eliminado!',
            'Usuario Eliminado con exito.',
            'success'
          )
        })
      } else if (
        /* Read more about handling dismissals below */
        result.dismiss === Swal.DismissReason.cancel
      ) {
        swalWithBootstrapButtons.fire(
          'Cancelado',
          `Usuario ${cliente.nombre} ${cliente.apellido} a salvo :)`,
          'error'
        )
      }
    })
  }

  }
