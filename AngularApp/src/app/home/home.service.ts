import { Injectable } from '@angular/core';
import { Http, HttpModule, Response, Headers, RequestOptions } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import 'rxjs/add/operator/map';

// import { Observable } from 'rxjs/Observable';

@Injectable()
export class HomeService {

  constructor(private http: Http) { }

  loginUser(loginUser) {
    let header = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: header });
    return this.http.post('http://localhost:58406/api/security/login', loginUser, options)
      .map((response: Response) => {
        return response.json();
      });
  }
}
