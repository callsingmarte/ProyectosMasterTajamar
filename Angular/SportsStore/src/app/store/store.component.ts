import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ProductRepository } from '../model/product.repository';
import { Product } from '../model/product.model';
import { CounterDirective } from './counter.directive';
import { CartSummaryComponent } from './cart-summary/cart-summary.component';
import { Cart } from '../model/cart.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-store',
  imports: [CommonModule, FormsModule, CounterDirective,
    CartSummaryComponent],
  standalone: true,
  templateUrl: './store.component.html',
  styleUrl: './store.component.css'
})
export class StoreComponent {

  selectedCategory: string | undefined;
  productsPerPage = 4;
  selectedPage = 1;

  constructor(private repository: ProductRepository,
    private cart: Cart, private router: Router) { }

  get products(): Product[] {
    let pageIndex = (this.selectedPage - 1) * this.productsPerPage;
    return this.repository.getProducts(this.selectedCategory)
      .slice(pageIndex, pageIndex + this.productsPerPage);
  }
  get categories(): string[] {
    return this.repository.getCategories();
  }
  changePage(newPage: number) {
    this.selectedPage = newPage;
  }

  changePageSize(newSize: number) {
    this.productsPerPage = Number(newSize);
    this.changePage(1);
  }

  //get pageNumbers(): number[] {
  //  return Array(Math.ceil(this.repository
  //    .getProducts(this.selectedCategory).length / this.productsPerPage))
  //    .fill(0).map((x, i) => i + 1);
  //}

  get pageCount(): number {
    return Math.ceil(this.repository
        .getProducts(this.selectedCategory).length / this.productsPerPage)
  }

  changeCategory(newCategory?: string) {
    this.selectedCategory = newCategory;
  }

  addProductToCart(product: Product) {
    this.cart.addLine(product);
    this.router.navigateByUrl("/cart");
  }
}
