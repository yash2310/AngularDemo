import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { RequestOptions } from '@angular/http';
import { Headers } from '@angular/http';
import { debug } from 'util';

@Injectable()
export class AccountService {

  constructor(private _http: Http) { }

  reporteeData(Id) {
    debugger;
    // let header = new Headers({ 'Content-Type': 'application/json' });
    // let options = new RequestOptions({ headers: header });
    // return this.http.get('http://localhost:58406/api/reportee/reportees/' + Id)
    //   .map((response: Response) => {
    //     return response.json();
    //   });


    return this._http.get('http://localhost:58406/api/reportee/reportees/' + Id)
      .map((response: Response) => {
        return response.json();
      });

  }
}