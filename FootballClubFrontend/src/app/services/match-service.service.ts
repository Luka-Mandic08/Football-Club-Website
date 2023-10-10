import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MatchService {

  headers = new HttpHeaders({
    //'Authorization': 'Bearer your-token',
    'Content-Type': 'application/json'
  });

  constructor(private http: HttpClient) { }

  createMatch(match:any): Observable<any> {
    return this.http.post<any>('api/match/create',match,{headers: this.headers});
  }
}
