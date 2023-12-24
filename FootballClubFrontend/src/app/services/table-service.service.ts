import { Injectable } from '@angular/core';
import { CreateTableDto, Table } from '../model/table';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MatchPreview } from '../model/match';

@Injectable({
  providedIn: 'root'
})
export class TableService {

  headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin':'true',
  });

  route = 'http://localhost:5238/tables/'

  constructor(private http: HttpClient) { }

  createTable(table:CreateTableDto): Observable<Table[]> {
    return this.http.post<Table[]>(this.route,table,{headers: this.headers});
  }

  getAllBySeason(season:number): Observable<Table[]> {
    return this.http.get<Table[]>(this.route+season,{headers:this.headers});
  }

  update(table:Table): Observable<Table[]> {
    return this.http.put<Table[]>(this.route,table,{headers:this.headers});
  }

  delete(id:string): Observable<Table[]> {
    return this.http.delete<Table[]>(this.route+id,{headers:this.headers});
  }
}
