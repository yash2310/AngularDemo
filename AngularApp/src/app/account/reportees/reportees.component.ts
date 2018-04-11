import { Component, OnInit } from '@angular/core';
import { AccountService } from '../account.service';
import { Router } from '@angular/router';
// import { error } from 'protractor';

@Component({
  selector: 'app-reportees',
  templateUrl: './reportees.component.html',
  styleUrls: ['./reportees.component.css']
})
export class ReporteesComponent implements OnInit {
  reporteeData: any;
  constructor(private _reporteeService: AccountService, private router: Router) { }

  ngOnInit() {
    this._reporteeService.reporteeData(21).subscribe(
      data => {
        this.reporteeData = data;
      },
      error => {
        alert("Invalid Data");
      });
  }

  Link(reportee) {
    // debugger;
    this.router.navigate(['account', 'reporteegoal'], { queryParams: { data: btoa(reportee.Id + ':' + reportee.Name + ':' + reportee.Email) } });
  }
}