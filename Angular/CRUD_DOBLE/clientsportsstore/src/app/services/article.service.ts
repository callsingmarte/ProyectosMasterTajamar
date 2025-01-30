import { HttpClient, HttpHeaders } from "@angular/common/http";
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

  updateArticle(article: { id: number; name: string; categoryID: number, price: number; stock: number }): Observable<IArticle> {
    this.apiURL = "https://localhost:7122/api/Products_DB";
    return this.http.put<IArticle>(`${this.apiURL} + '/' + ${article.id}`, article);
  }

  createArticle(article: { name: string; categoryID: number, price: number; stock: number}) {
    this.apiURL = "https://localhost:7122/api/Products_DB";
    return this.http.post<IArticle>(this.apiURL, article);
  }

  updateArticlePrice(article: { id: number; price: number }): Observable<IArticle> {
    this.apiURL = "https://localhost:7122/api/Products_DB";
    const body = { ...article }; // Incluye el id y el nuevo price
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    return this.http.put<IArticle>(`${this.apiURL}/${article.id}`, body, { headers });
  }
}
