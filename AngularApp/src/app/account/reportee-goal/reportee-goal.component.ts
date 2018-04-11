import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-reportee-goal',
  templateUrl: './reportee-goal.component.html',
  styleUrls: ['./reportee-goal.component.css']
})
export class ReporteeGoalComponent implements OnInit {

  reporteeId: number;
  reporteeName: string;
  reporteeEmail: string;

  constructor(private activatedRoute: ActivatedRoute) { }

  ngOnInit() {

    let data = atob(this.activatedRoute.snapshot.queryParams['data']).split(':');

    this.reporteeId = Number(data[0]);
    this.reporteeName = data[1];
    this.reporteeEmail = data[2];
    alert(this.reporteeId);
  }

}
