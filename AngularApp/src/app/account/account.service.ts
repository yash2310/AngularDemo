import { Injectable } from '@angular/core';
import { Http, HttpModule, Response, Headers, RequestOptions } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import 'rxjs/add/operator/map';

@Injectable()
export class AccountService {

  constructor(private http: Http) { }

  reporteeData(Id) {
    return this.http.get('http://localhost:58406/api/reportee/reportees/' + Id)
      .map((response: Response) => {
        return response.json();
      });
  }
}