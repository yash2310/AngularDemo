import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HomeService } from '../home.service';
import { error } from 'util';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  Username: string;
  Password: string;
  loginData: any;

  constructor(private _loginService: HomeService, private router: Router) { }

  ngOnInit() {
    this.loginForm = new FormGroup({
      Username: new FormControl('', Validators.required),
      Password: new FormControl('', Validators.required)
    });
  }

  onClick(type) {
    this.router.navigate(['/home/' + type]);
  }

  onSubmit() {
    if (this.loginForm.valid) {
      this.loginData = {
        "Username": this.loginForm.controls["Username"].value,
        "Password": this.loginForm.controls["Password"].value,
      }

      this._loginService.loginUser(this.loginData).subscribe(
        data => {
          data;
          let loginData = {
            "Id": data.Id,
            "Name": data.Name,
            "Email": data.Email,
            "EmployeeNo": data.EmployeeNo,
            "ContactNo": data.ContactNo,
            "JoiningDate": data.JoiningDate,
            "ImageUrl": data.ImageUrl,
            "NewUser": data.NewUser,
            "ReportingManager": data.ReportingManager,
            "Designation": data.Designation,
            "Department": data.Department,
            "Organization": data.Organization,
            "Roles": data.Roles,
          }

          localStorage.setItem('UserData', JSON.stringify(loginData));
          // alert(JSON.parse(localStorage.getItem('UserData')).Name);
          // alert(JSON.parse(localStorage.getItem('UserData')).Email);
          // alert(JSON.parse(localStorage.getItem('UserData')).ReportingManager.Name);
        },
        error => {
          alert(error.status);
        }
      );
    }
  }
}