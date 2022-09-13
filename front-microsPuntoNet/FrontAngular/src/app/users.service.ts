import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
//import configurl from '../assets/config/config.json'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from 'src/Model/User';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  configurl = require('../assets/config/config.json');

  url = this.configurl.apiServer.url + '/user';
  constructor(private http: HttpClient) { }
  getUserList(): Observable<User[]> {
    return this.http.get<User[]>(this.url);
  }
  postUserData(userData: User): Observable<User> {
    const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
    return this.http.post<User>(this.url, userData, httpHeaders);
  }
  updateUser(user: User): Observable<User> {
    const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
    return this.http.put<User>(this.url, user, httpHeaders);
  }
  deleteUserById(id: number): Observable<number> {
    return this.http.delete<number>(this.url + '/' + id);
  }
  getUserDetailsById(id: string): Observable<User> {
    return this.http.get<User>(this.url + '/' + id);
  }
}