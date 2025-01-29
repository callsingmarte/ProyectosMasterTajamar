import { Routes } from '@angular/router';
import { ArticleComponent } from './article/article.component';
import { HomeComponent } from './home/home.component';
import { ArticleFormComponent } from './article-form/article-form.component';

export const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full'},
  { path: 'article', component: ArticleComponent },
  { path: 'article-add', component: ArticleFormComponent },
  { path: 'article-edit/:id', component: ArticleFormComponent },
];
