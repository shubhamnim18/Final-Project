import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  constructor(private route:Router){}
  ngOnInit(): void {
  }
  user!:any;
  pass!:any;
  login(){
  if(this.user=="admin" && this.pass=="password"){
  }
}
}