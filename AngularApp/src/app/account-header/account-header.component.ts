import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Event, NavigationStart, NavigationEnd, NavigationError, RoutesRecognized, RouteConfigLoadStart } from '@angular/router';

@Component({
  selector: 'app-account-header',
  templateUrl: './account-header.component.html',
  styleUrls: ['./account-header.component.css']
})
export class AccountHeaderComponent implements OnInit {

  username: any;
  constructor(private router: Router) {
    this.username = JSON.parse(localStorage.getItem("UserData")).Name;
    // if(event instanceof NavigationStart) {
    //   //An event triggered when navigation starts.
    // }else if(event instanceof RoutesRecognized) {
    //   //An event triggered when the Router parses the URL and the routes are recognized.
    // }else if(event instanceof RouteConfigLoadStart) {
    //   //An event triggered before the Router lazy loads a route configuration.
    // }else if(event instanceof RouteConfigLoadEnd) {
    //   //An event triggered after a route has been lazy loaded.
    // }else if(event instanceof NavigationEnd) {
    //   //An event triggered when navigation ends successfully.
    // }else if(event instanceof NavigationCancel) {
    //   //An event triggered when navigation is canceled. This is due to a Route Guard returning false during navigation.
    // }else if(event instanceof NavigationError) {
    //   //An event triggered when navigation fails due to an unexpected error.
    // }

  }

  ngOnInit() {
    // debugger;
    // if (localStorage.getItem('UserData') == null) {
    //   this.router.navigate(['home/login']);
    // }
  }

  onClick(type) {
    if(type=="logout"){
      localStorage.removeItem("UserData");
      localStorage.clear();
    }

    this.router.navigate(['/account/' + type]);
  }
}
