import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreatePlayerDto } from '../model/player';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {

  headers = new HttpHeaders({
    //'Authorization': 'Bearer your-token',
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin':'true'
  });

  route = 'http://localhost:5238/'

  constructor(private http: HttpClient) { }

  createPlayer(player:CreatePlayerDto): Observable<any> {
    return this.http.post<any>(this.route + 'players' , player, {headers: this.headers});
  }
}
