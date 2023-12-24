import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ActiveAndLoanedPlayersDto, CreatePlayerDto, GetStatisticsForPlayerDto, PlayerDto } from '../model/player';
import { PlayerStatistics } from '../model/player-statistics';
import { PlayerForSquad } from '../model/players-for-squad';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {

  headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin':'true',
  });

  route = 'http://localhost:5238/players/'

  constructor(private http: HttpClient) { }

  createPlayer(player:CreatePlayerDto): Observable<any> {
    return this.http.post<any>(this.route, player, {headers: this.headers});
  }

  getAll(): Observable<PlayerForSquad[]> {
    return this.http.get<PlayerForSquad[]>(this.route+"getAll", {headers: this.headers});
  }

  getActiveAndLoaned(): Observable<ActiveAndLoanedPlayersDto> {
    return this.http.get<ActiveAndLoanedPlayersDto>(this.route+"getActiveAndLoaned", {headers: this.headers});
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
