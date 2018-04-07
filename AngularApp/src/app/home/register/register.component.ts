import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormControl, Validators } from '@angular/forms';

const now = new Date();
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  host: {
    "(document:click)": "onClick($event)"
  }
})
export class RegisterComponent implements OnInit {

  @ViewChild("d") datePicker;
  public regModel: any;
  constructor(private _eref: ElementRef) { }

  ngOnInit() {

    this.regModel = new FormGroup({
      name: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required),
      employeeno: new FormControl('', Validators.required),
      doj: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
      confirmpassword: new FormControl('', Validators.required)
    });

  }

  onSubmit(regModel) { }

  public onClick(event) { // close the datepicker when user clicks outside the element
    debugger;
    if (event.target.id.includes("dp")) {
    }
    else if (event.target.id.includes("dpDiv")) {
    }
    else{
      this.datePicker.close();
    }
  }
}