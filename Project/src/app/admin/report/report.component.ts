import { Component, OnInit } from '@angular/core';
import { MainService } from 'src/app/shared/main.service';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit{
  report:any[]=[];
  constructor(private service:MainService){}
  ngOnInit(): void {
      this.getReport();
  }
  getReport(){
    this.service.getReport().subscribe((res:any)=>{
      this.report=res;
      console.log(res);
    })
  }

}
