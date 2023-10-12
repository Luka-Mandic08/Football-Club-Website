import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MatchService {

  headers = new HttpHeaders({
    //'Authorization': 'Bearer your-token',
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin':'true'
  });

  route = 'http://localhost:5238/'

  constructor(private http: HttpClient) { }

  createMatch(match:any): Observable<any> {
    return this.http.post<any>(this.route+'matches',match,{headers: this.headers});
  }
}
