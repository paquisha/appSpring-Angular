import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { autores } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class AutoresService {
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get<autores[]>(`${environment.apiAutores}`);
    }
}