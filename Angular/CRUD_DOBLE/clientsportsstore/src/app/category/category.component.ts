import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CategoryService } from '../services/category.service';
import { ICategory } from './category';

@Component({
  selector: 'app-category',
  imports: [FormsModule, CommonModule],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent {

  public categories: ICategory[] = []
  opcionSeleccionado: number = 0;
  verSeleccion: number = 0;
  constructor(private categoriesService: CategoryService) { }

  @Input() idCategory: number = 0;
  @Output() idCategoryEvent = new EventEmitter<number>();

  ngOnInit() {
    this.cargarCategorias();
  }

  ngDoCheck() {
    this.opcionSeleccionado = this.idCategory;
  }

  cargarCategorias() {
    this.categoriesService.getCategories()
      .subscribe({
        next: (categories) => this.categories = categories,
        error: (error) => console.error(error),
        complete: () => console.log('Categories cargadas correctamente')
      })
  }

  capturar() {
    this.verSeleccion = this.opcionSeleccionado;
    this.idCategory = this.verSeleccion;
    this.idCategoryEvent.emit(this.idCategory);
  }
}
