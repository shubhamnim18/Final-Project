import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { service } from './service';
import { user } from './user';

@Injectable({
  providedIn: 'root'
})
export class MainService {

  path:string="https://localhost:7086/api/ProductServices";
  constructor(private http:HttpClient) { }

  addService(formData:FormData){
    return this.http.post(this.path,formData);
  }

  userPath="https://localhost:7086/api/Users";

  authenticate(data:user){
    return this.http.post(this.userPath+'/authenticate',data);
  }

  //Tokens
  storeToken(tokenValue:string){
    localStorage.setItem('token',tokenValue);
  }

  getToken(){
    return localStorage.getItem('token');
  }

  isLoggedIn():boolean{
    return !!localStorage.getItem('token');
  }
}
