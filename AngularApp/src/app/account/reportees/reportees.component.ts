import { Component, OnInit } from '@angular/core';
import { AccountService } from '../account.service';
// import { error } from 'protractor';

@Component({
  selector: 'app-reportees',
  templateUrl: './reportees.component.html',
  styleUrls: ['./reportees.component.css']
})
export class ReporteesComponent implements OnInit {
  reporteeData: any;
  constructor(private _reporteeService: AccountService) { }

  ngOnInit() {
    debugger;
    // this._reporteeService.reporteeData(21).subscribe(
    //   data => {
    //     data;
    //     // this.reporteeData = {
    //     //   "Id": data.Id,
    //     //   "Name": data.Name,
    //     //   "Email": data.Email,
    //     //   "EmployeeNo": data.EmployeeNo,
    //     //   "JoiningDate": data.JoiningDate,
    //     //   "ReportingManager": data.ReportingManager,
    //     //   "Designation": data.Designation,
    //     //   "Department": data.Department,
    //     //   "Organization": data.Organization,
    //     //   "Roles": data.Roles,
    //     // }
    //   },
    //   error => {
    //     alert(error.status);
    //   });
  }
}