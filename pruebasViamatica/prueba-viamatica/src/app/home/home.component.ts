import { Component } from '@angular/core';
import { first } from 'rxjs/operators';

import { autores } from '@app/_models';
import { AutoresService } from '@app/_services/autores.service';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {
    loading = false;
    autores?: autores[];

    constructor(private autorService: AutoresService) { }

    ngOnInit() {
        this.loading = true;
        this.autorService.getAll().subscribe(autors =>{
            this.loading = true;
            this.autores = autors;
            console.log(this.autores);
            this.autores.forEach((nombre) =>{
                console.log(nombre);
            })
        });
    }
}