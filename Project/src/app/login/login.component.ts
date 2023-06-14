import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { user } from '../shared/user';
import { MainService } from '../shared/main.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  constructor(private route:Router,private service:MainService){}
  ngOnInit(): void {
  }
  user:user=new user();
  login(){
    this.service.authenticate(this.user).subscribe({
      next:(res:any)=>{ 
        console.log(res.token);
        this.service.storeToken(res.token);
        this.route.navigate(['admin']);
      },
      error:err=>{
        alert("Invalid credentials");
      }
  });
  }
}