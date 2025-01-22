import { Component } from '@angular/core';
import { MODES, SharedStateService } from '../shared-state.service';
import { Model } from '../../model/repository.model';
import { Product } from '../../model/product.model';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';

@Component({
  selector: 'app-table',
  imports: [CommonModule, RouterModule],
  templateUrl: './table.component.html',
  styleUrl: './table.component.css'
})
export class TableComponent {

  category: string | null = null

  constructor(private model: Model, activeRoute: ActivatedRoute)
  {
    activeRoute.params.subscribe(params => {
      this.category = params["category"] || null;
    })
  }

  getProduct(key: number): Product | undefined {
    return this.model.getProduct(key);
  }
  getProducts(): Product[] {
    return this.model.getProducts().filter(p => this.category == null || p.category == this.category);
  }

  get categories() : string[] {
    return (this.model.getProducts().map(p => p.category)
      .filter((c, index, array) => c != undefined && array.indexOf(c) == index)) as string[];
  }


  deleteProduct(key?: number) {
    if (key != undefined) {
      this.model.deleteProduct(key);
    }
  }

  //editProduct(key?: number) {
  //  this.state.update(MODES.EDIT, key)
  //}

  //createProduct() {
  //  this.state.update(MODES.CREATE)
  //}
}
