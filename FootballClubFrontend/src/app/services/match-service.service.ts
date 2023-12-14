import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreateMatch, MatchEvent, MatchPreview } from '../model/match';
import { Squads } from '../model/players-for-squad';
import { MatchStatistics, MatchStatisticsDto } from '../model/match-statistics';
import { PlayerStatistics, PlayerStatisticsDto } from '../model/player-statistics';

@Injectable({
  providedIn: 'root'
})
export class MatchService {

  headers = new HttpHeaders({
    //'Authorization': 'Bearer your-token',
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin':'true',
    'Authorization': ''
  });

  route = 'http://localhost:5238/matches/'

  constructor(private http: HttpClient) { }

  createMatch(match:CreateMatch): Observable<any> {
    return this.http.post<any>(this.route,match,{headers: this.headers});
  }

  getFixtures(): Observable<MatchPreview[]> {
    return this.http.get<MatchPreview[]>(this.route+'fixtures',{headers:this.headers});
  }

  getResults(): Observable<MatchPreview[]> {
    return this.http.get<MatchPreview[]>(this.route+'results',{headers:this.headers});
  }

  getByDate(date:string): Observable<MatchPreview> {
    return this.http.get<MatchPreview>(this.route+'getByDate/'+date,{headers:this.headers});
  }

  getMatchEvents(id:string): Observable<MatchEvent[]> {
    return this.http.get<MatchEvent[]>(this.route+'matchevents/'+id,{headers:this.headers});
  }

  updateMatchEvents(id:string,events:MatchEvent[]): Observable<MatchEvent[]> {
    return this.http.put<MatchEvent[]>(this.route+'update/matchevents/'+id,events,{headers:this.headers});
  }

  getMatchSquads(id:string): Observable<Squads> {
    return this.http.get<Squads>(this.route+'squads/'+id,{headers:this.headers});
  }

  updateMatchSquads(id:string,squads: Squads): Observable<Squads> {
    return this.http.put<Squads>(this.route+'update/squads/'+id,squads,{headers:this.headers});
  }

  getMatchStatistics(id:string): Observable<MatchStatisticsDto> {
    return this.http.get<MatchStatisticsDto>(this.route+'statistics/'+id,{headers:this.headers});
  }

  updateMatchStatistics(id:string,dto: MatchStatisticsDto): Observable<MatchStatisticsDto> {
    return this.http.put<MatchStatisticsDto>(this.route+'update/statistics/'+id,dto,{headers:this.headers});
  }

  getPlayerStatistics(id:string) : Observable<PlayerStatisticsDto> {
    return this.http.get<PlayerStatisticsDto>(this.route+'playerstatistics/'+id,{headers:this.headers});
  }

  updatePlayerStatistics(statistics:PlayerStatistics) : Observable<PlayerStatisticsDto> {
    return this.http.put<PlayerStatisticsDto>(this.route+'update/playerstatistics',statistics,{headers:this.headers});
  }
}
