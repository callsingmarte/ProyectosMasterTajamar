import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IArticle } from "../article/article";

@Injectable({
  providedIn: 'root'
})

export class ArticleService {
  private apiURL: string = "";
  constructor(private http: HttpClient) { }

  getArticles(): Observable<IArticle[]> {
    this.apiURL = "https://localhost:7122/api/Products_DB";
    return this.http.get<IArticle[]>(this.apiURL);
  }

  getArticle(articleId: string): Observable<IArticle> {
    this.apiURL = "https://localhost:7122/api/Products_DB";
    return this.http.get<IArticle>(this.apiURL + '/' + articleId);
  }

  deleteArticle(articleId: string): Observable<IArticle> {
    this.apiURL = "https://localhost:7122/api/Products_DB";
    return this.http.delete<IArticle>(this.apiURL + '/' + articleId);
  }
}
