import { Injectable } from '@angular/core';
import { Article, CreateArticleDto } from '../model/article';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {

  headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin':'true',
  });

  route = 'http://localhost:5238/articles/'

  constructor(private http: HttpClient) { }

  createArticle(article:CreateArticleDto): Observable<any> {
    return this.http.post<any>(this.route,article,{headers: this.headers});
  }

  getByType(type:number,page:number): Observable<Article[]> {
    return this.http.get<Article[]>(this.route+"getByType/"+type+'/'+page,{headers: this.headers});
  }

  getForMatch(matchId:string): Observable<Article[]> {
    return this.http.get<Article[]>(this.route+"getForMatch/"+matchId,{headers: this.headers});
  }

  getForPlayer(playerId:string): Observable<Article[]> {
    return this.http.get<Article[]>(this.route+"getForPlayer/"+playerId,{headers: this.headers});
  }

  getById(id:string): Observable<Article> {
    return this.http.get<Article>(this.route+"getById/"+id,{headers: this.headers});
  }

  getForHomePage(): Observable<Article[]> {
    return this.http.get<Article[]>(this.route+"getForHomePage",{headers: this.headers});
  }
  
}
