import { Component } from '@angular/core';
import { IArticle } from './article';
import { ArticleService } from '../services/article.service';
import { catchError, of } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NgxPaginationModule } from 'ngx-pagination';
import { DiscountEditorComponent } from '../discount-editor/discount-editor.component';
import * as FileSaver from 'file-saver';
import { StockRowDirective } from '../directives/stock-row.directive';

declare const bootstrap: any;

@Component({
  selector: 'app-article',
  imports: [FormsModule, CommonModule, RouterModule,
    NgxPaginationModule, DiscountEditorComponent, StockRowDirective],
  templateUrl: './article.component.html',
  styleUrl: './article.component.css'
})
export class ArticleComponent {
  public articles: IArticle[] = [];
  public filteredArticles: IArticle[] = [];
  categoryFilter: string = 'All';

  query: string = '';
  //paginacion
  pageActual: number = 1;
  itemsPerPage: number = 6;

  //descuentos
  discountPercentage: number = 0;
  bootstrapModal: any;
  selectedArticle: any = null;
  discountOptions: number[] = [5, 10, 15, 25, 50]

  //ordenacion
  sortColumn: string = ''; //Columna a ordenar
  sortDirection: string = 'asc'; //Direccion de ordenacion (asc o desc)

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
        this.filterArticles();
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

  get totalPages(): number {
    return Math.ceil(this.filteredArticles.length / this.itemsPerPage);
  }

  //Paginacion
  nextPage() {
    if (this.pageActual < this.totalPages) {
      this.pageActual++;
    }
  }

  prevPage() {
    if (this.pageActual > 1) {
      this.pageActual--;
    }
  }

  getPagesArray(): number[] {
    return Array.from({ length: this.totalPages }, (_, i) => i + 1);
  }
  //Ordenacion
  toggleSort(column: string, event: Event): void {
    event.preventDefault();
    if (this.sortColumn === column) {
      //Alterno la direccion en los sucesivos clicks
      this.sortDirection = this.sortDirection === "asc" ? 'desc' : 'asc';
      this.sortArticles();
    } else {
      //Cambiado de columna
      this.sortColumn = column;
      this.sortDirection = 'asc';
      //ordenamos los articulos
      this.sortArticles();
    }
  }

  sortArticles(): void {
    if (this.sortColumn) {
      this.filteredArticles.sort((a, b) => {
        const valueA = a[this.sortColumn as keyof IArticle];
        const valueB = b[this.sortColumn as keyof IArticle];

        if (valueA === undefined || valueB === undefined) {
          return 0; // Si alguno es undefined, no cambiar el orden
        }

        if (valueA < valueB) return this.sortDirection === 'asc' ? -1 : 1;
        if (valueA > valueB) return this.sortDirection === 'asc' ? 1 : -1;
        return 0;
      });
    }
  }

  //Modales
  openDiscountModal(article?: any) {
    this.discountPercentage = 0;
    if (article || article != undefined) {
      this.selectedArticle = article;
      this.discountPercentage = this.discountOptions[0];
      const modalElement: any = document.getElementById('discountModal_Article');
      const bootstrapModal = new bootstrap.Modal(modalElement);
      bootstrapModal.show();
    } else {
      const modalElement: any = document.getElementById('discountModal');
      const bootstrapModal = new bootstrap.Modal(modalElement);
      bootstrapModal.show();
    }
  }

  applyDiscount() {
    if (this.discountPercentage > 0) {
      //Si hay un articulo seleccionado, aplicar a ese
      if (this.selectedArticle && this.selectedArticle != null) {
        //aplicar descuento a un articulo
        this.applyDiscount_Article(this.selectedArticle, this.discountPercentage);
      } else {
        //aplicar a todos los articulos
        this.articles.forEach(article => {
          this.applyDiscount_Article(article, this.discountPercentage);
        })
      }
    } else {
      this.articles.forEach(article => {
        this.applyDiscount_Article(article, this.discountPercentage);
      })
    }
  }

  //aplicar un descuento a un articulo
  applyDiscount_Article(selectedArticle: IArticle, discountPercentage: number): void {
    if (!selectedArticle) {
      console.error('No hay articulo seleccionado para el descuento');
      return
    }
    //Calcula el descuento
    const discountAmount = (selectedArticle.price * discountPercentage) / 100;
    //Calcula el nuevo precio despues del descuento
    const newPrice = selectedArticle.price - discountAmount;
    //Asignamos el nuevo precio asegurando que no es negativo
    selectedArticle.price = Math.max(newPrice, 0);

    //Guardar El articulo modificado
    this.saveDiscount(selectedArticle);
    this.selectedArticle = null;
    //Cerrar la modal
    const modalElement: any = document.getElementById('discountModal_Article');
    if (modalElement) {
      modalElement.classList.remove('show');
      modalElement.style.display = 'none';
      document.body.classList.remove('modal-open');
      const backdrop = document.querySelector('.modal-backdrop');
      if (backdrop) {
        backdrop.remove();
      }
    } else {
      console.error("Modal element not found");
    }
  }

  saveDiscount(article: IArticle): void {
    this.articleService.updateArticlePrice(article)
      .subscribe({
        next: (updateArticle: IArticle) => {
          console.log('Article updated successfull :', updateArticle);
        },
        error: (err) => {
          console.log('Error updating article:', err);
        }
      })
  }

  //Recibe el porcentaje de descuento y lo asigna
  onDiscountSelected(discount: number) {
    this.discountPercentage = discount;
  }

  //Excel
  exportToCSV() {
    const csvContent = this.generateCSV(this.filteredArticles);
    const blob = new Blob([csvContent], { type: 'text/csv' });
    FileSaver.saveAs(blob, 'articles.csv');
  }
  generateCSV(articles: IArticle[]): string {
    let csv = 'ID; NAME; CATEGORY NAME; PRICE; STOCK \n';
    articles.forEach(article => {
      const row = `${article.id}; ${article.name}; ${article.category.categoryName}; ${article.price}; ${article.stock} \n`;
      csv += row;
    })
    return csv;
  }

  //Gestion del Stock
  onStockInput(event: Event): void {
    const inputElement = event.target as HTMLInputElement
    const newStock = Number(inputElement.value);
    this.selectedArticle.stock = newStock; //Actualizamos el valor del nuevo stock
  }

  //Funcion que escucha el evento del StockEdit
  onStockEdit(article: IArticle) {
    console.log('Articulo recibido: ', article);
    //abrir un modal que muestre el articulo
    this.openModalStock(article);
  }

  private modalInstance: any; //Propiedad para guardar la instancia de la modal
  openModalStock(article: IArticle): void {
    this.selectedArticle = { ...article }; //copiar el articulo seleccionado
    const modalElement: HTMLElement | null = document.getElementById('stockModal');
    if (modalElement) {
      this.modalInstance = new bootstrap.Modal(modalElement, {
        backdrop: 'static', //evita que el modal se cierre al hacer click fuera de el
        Keyboard: false //desactiva el cierre con teclado
      });
      this.modalInstance.show();
    }
  }

  closeModalStock(): void {
    if (this.modalInstance) {
      this.modalInstance.hide();
      this.modalInstance = null;
    } else {
      console.log('no hay instancia de modal para cerrar');
    }
  }

  updateStock(): void {
    if (this.selectedArticle && this.selectedArticle.stock >= 0) {
      this.articleService.updateArticleStock(this.selectedArticle)
        .subscribe({
          next: (updateArticle: IArticle) => {
            //Actualizar el stock en la lista principal
            this.articles = this.articles.map(article =>
              article.id === updateArticle.id ? { ...article, stock: updateArticle.stock } : article
            )
            //filtrar nuevamente los datos
            this.filteredArticles = [...this.articles];
            this.closeModalStock();
          },
          error: (err) => {
            console.log('Error al actualizar el articulo', err);
          }
        })
    } else {
      alert('La cantidad del stock no puede ser negativa');
    }
  }

}
