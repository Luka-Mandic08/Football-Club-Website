import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AllPlayersDto, CreatePlayerDto, GetStatisticsForPlayerDto, PlayerDto } from '../model/player';
import { PlayerStatistics } from '../model/player-statistics';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {

  headers = new HttpHeaders({
    //'Authorization': 'Bearer your-token',
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin':'true',
    'Authorization': ''
  });

  route = 'http://localhost:5238/players/'

  constructor(private http: HttpClient) { }

  createPlayer(player:CreatePlayerDto): Observable<any> {
    return this.http.post<any>(this.route, player, {headers: this.headers});
  }

  getAllPlayers(): Observable<AllPlayersDto> {
    return this.http.get<AllPlayersDto>(this.route, {headers: this.headers});
  }

  getPlayerById(id:string): Observable<PlayerDto> {
    return this.http.get<PlayerDto>(this.route + "getById/" + id, {headers: this.headers});
  }

  getPlayerByName(name:string): Observable<PlayerDto> {
    return this.http.get<PlayerDto>(this.route + "getByName/" + name, {headers: this.headers});
  }

  getStatisticsForPlayer(dto:GetStatisticsForPlayerDto): Observable<PlayerStatistics> {
    return this.http.put<PlayerStatistics>(this.route + "getStatistics", dto, {headers: this.headers});
  }
}
