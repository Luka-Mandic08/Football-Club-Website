import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { LoginDto, RegisterDto } from '../model/user';
import { catchError, map, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin':'true',
  });

  route = 'http://localhost:5238/users/'

  constructor(private http: HttpClient) { }

  login(dto:LoginDto): Observable<any> {
    return this.http.post<any>(this.route+'login',dto,{headers: this.headers})
  }

  registerUser(dto:RegisterDto): Observable<any> {
    return this.http.post<any>(this.route+'register/user',dto,{headers: this.headers});
  }

  registerAdmin(dto:RegisterDto): Observable<any> {
    return this.http.post<any>(this.route+'register/admin',dto,{headers: this.headers});
  }
}
