import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICategory } from '../category/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private apiURL: string = "";

  constructor(private http: HttpClient) { }

  getCategories(): Observable<ICategory[]> {
    this.apiURL = "https://localhost:7122/api/Categories_DB";
    return this.http.get<ICategory[]>(this.apiURL);
  }
  getCategory(categoryId: string): Observable<ICategory> {
    this.apiURL = "https://localhost:7122/api/Categories_DB";
    return this.http.get<ICategory>(this.apiURL + '/' + categoryId);
  }
}
