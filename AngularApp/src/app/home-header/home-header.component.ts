import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-home-header',
  templateUrl: './home-header.component.html',
  styleUrls: ['./home-header.component.css']
})
export class HomeHeaderComponent implements OnInit {

  constructor(private router: Router, private route: ActivatedRoute) {
    // debugger;
   }

  ngOnInit() {
    // debugger;
  }

  onClick(type) {
    this.router.navigate(['/home/'+type]);
  }

  
}
