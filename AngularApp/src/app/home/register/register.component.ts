import { Component, OnInit, ViewChild, ElementRef, Input } from '@angular/core';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HomeService } from '../home.service';

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
  public regData: any;

  alertType: string;
  alertMessage: string;
  staticAlertClosed = true;

  constructor(private _eref: ElementRef, private _regUser: HomeService) { }

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

  onSubmit() {
    if (this.regModel.valid) {
      let dateData = this.regModel.controls["doj"].value;
      this.regData = {
        "Name": this.regModel.controls["name"].value,
        "Email": this.regModel.controls["email"].value,
        "EmployeeNo": this.regModel.controls["employeeno"].value,
        "JoiningDate": dateData.day + "/" + dateData.month + "/" + dateData.year,
        "Password": this.regModel.controls["password"].value
      }

      this._regUser.registerUser(this.regData).subscribe(
        data => {
          if (data == true) {
            this.staticAlertClosed = false;
            this.alertType = "success";
            this.alertMessage = "User Registered Successfully";
            setTimeout(() => this.staticAlertClosed = true, 10000);
            this.ResetForm();
          } else {
            this.staticAlertClosed = false;
            this.alertType = "warning";
            this.alertMessage = "Please try again";
            setTimeout(() => this.staticAlertClosed = true, 10000);
          }
        });
    }
  }

  public onClick(event) { // close the datepicker when user clicks outside the element
    if (event.target.id.includes("dp")) {
    }
    else if (event.target.id.includes("dpDiv")) {
    }
    else {
      this.datePicker.close();
    }
  }

  public ResetForm() {
    this.ngOnInit();
  }
}