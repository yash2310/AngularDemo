import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-reportee-goal',
  templateUrl: './reportee-goal.component.html',
  styleUrls: ['./reportee-goal.component.css']
})
export class ReporteeGoalComponent implements OnInit {

  reporteeId: number;
  reporteeName: string;
  reporteeEmail: string;
  goalModel: any;

  model: NgbDateStruct;
  date: { year: number, month: number };
  btnUpdate: boolean = false;

  constructor(private activatedRoute: ActivatedRoute) { }

  ngOnInit() {

    this.goalModel = new FormGroup({
      goal: new FormControl('', Validators.required),
      goalType: new FormControl('', Validators.required),
      weight: new FormControl('', Validators.required),
      desc: new FormControl('', Validators.required),
      stdate: new FormControl('', Validators.required),
      enddate: new FormControl('', Validators.required),
      reveiwer: new FormControl('', Validators.required)
    });

    let data = atob(this.activatedRoute.snapshot.queryParams['data']).split(':');

    this.reporteeId = Number(data[0]);
    this.reporteeName = data[1];
    this.reporteeEmail = data[2];
    // alert(this.reporteeName);
  }

}