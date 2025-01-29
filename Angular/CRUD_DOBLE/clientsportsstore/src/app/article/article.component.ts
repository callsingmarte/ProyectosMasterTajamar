import { Component } from '@angular/core';
import { IArticle } from './article';
import { ArticleService } from '../services/article.service';
import { catchError, of } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-article',
  imports: [FormsModule, CommonModule, RouterModule],
  templateUrl: './article.component.html',
  styleUrl: './article.component.css'
})
export class ArticleComponent {
  public articles: IArticle[] = [];
  public filteredArticles: IArticle[] = [];
  categoryFilter: string = 'All';
  query: string = '';
  constructor(private articleService: ArticleService) { }

  ngOnInit() {
    this.cargarDatos();
  }

  filterArticles() {
    //Por categoria
    let filterByCategory = this.categoryFilter === 'All' ? this.articles :
      this.articles.filter(article => article.category.categoryName == this.categoryFilter)
    //Por nombre
    this.filteredArticles = filterByCategory.filter(article => article.name.toLowerCase().includes(this.query.toLowerCase()))

  }

  cargarDatos() {
    this.articleService.getArticles().pipe(
      catchError((error) => {
        console.error(error);
        return of([]);
      })
    ).subscribe({
      next: (articles) => {
        this.articles = articles;
      },
      error: (error) => console.error(error)
    });
  }

  delete(article: IArticle) {
    this.articleService.deleteArticle(article.id.toString()).pipe(
      catchError((error) => {
        console.error(error);
        return of(null);
      })
    ).subscribe({
      next: () => this.cargarDatos(),
      error: (error) => console.error(error)
    });
  }

}
