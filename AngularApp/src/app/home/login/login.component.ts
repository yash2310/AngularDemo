import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HomeService } from '../home.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  Username: string;
  Password: string;

  constructor() { }

  ngOnInit() {
    this.loginForm = new FormGroup({
      Username: new FormControl('', Validators.required),
      Password: new FormControl('', Validators.required)
    });
  }

  onSubmit() {
    debugger;
    if (this.loginForm.valid) {
      // alert(this.loginForm.controls["Username"].value);
      // alert(this.loginForm.controls["Password"].value);

      // console.log("Form Submitted!");
      // loginUser(this.loginForm);
    }
  }
}
