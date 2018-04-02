import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class HomeService {

  constructor(private http: Http) { }

  loginUser(loginUser) {
    let header = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: header });
    return this.http.post('http://localhost:58406/api/security/login', loginUser, options).subscribe((data) => JSON.stringify(data));
  }
}
