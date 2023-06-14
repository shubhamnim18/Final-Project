import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { service } from './service';

@Injectable({
  providedIn: 'root'
})
export class MainService {

  path:string="https://localhost:7086/api/ProductServices";
  constructor(private http:HttpClient) { }

  addService(formData:FormData){
    return this.http.post(this.path,formData);
  }
}
