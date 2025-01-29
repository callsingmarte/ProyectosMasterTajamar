import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { CategoryComponent } from '../category/category.component';
import { ArticleService } from '../services/article.service';
import { CategoryService } from '../services/category.service';
import { ICategory } from '../category/category';
import { IArticle } from '../article/article';

@Component({
  selector: 'app-article-form',
  imports: [ReactiveFormsModule, RouterModule,
    CommonModule, CategoryComponent],
  templateUrl: './article-form.component.html',
  styleUrl: './article-form.component.css'
})
export class ArticleFormComponent {

  constructor(
    private fb: FormBuilder,
    private articleServices: ArticleService,
    private categoryServices: CategoryService,
    private router: Router, private activatedRoute: ActivatedRoute
  ) { }

  modoEdicion: boolean = false;
  formGroup!: FormGroup;
  articleId!: number;
  categoryId: number = 0;

  formTitle: string = 'Add Article';

  public categories: ICategory[] = []

  ngOnInit() {
    this.formGroup = this.fb.group({
      name: '',
      category: '',
      price: '',
      stock: '',
    })

    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        this.cargarCategorias();
        return;
      }
      this.modoEdicion = true;
      this.articleId = params["id"];
      this.formTitle = 'Edit Article';

      this.articleServices.getArticle(this.articleId.toString())
        .subscribe({
          next: (article) => this.cargarForm(article),
          error: (error) => console.error('Error al obtener el articulo: ', error)
        });
      this.recuperarCategory();
    })
  }

  cargarForm(article: IArticle) {
    this.formGroup.patchValue({
      name: article.name,
      category: article.category,
      price: article.price,
      stock: article.stock
    })
  }

  recuperarCategory() {
    this.articleServices
      .getArticle(this.articleId.toString())
      .subscribe((article) => {
        if (article.categoryID !== undefined) {
          this.categoryId = article.categoryID;
        } else {
          console.error('CategoryID is undefined for article ', article);
        }
      })
  }

  cargarCategorias() {
    this.categoryServices.getCategories()
      .subscribe({
        next: (categories) => this.categories = categories,
        error: (error) => console.error(error),
        complete: () => console.log('Categories cargadas correctamente')
      })
  }

  get f() {
    return this.formGroup.controls;
  }

  receiveCategoryID($event: number) {
    this.categoryId = $event;
    console.log(this.categoryId);
  }

}
