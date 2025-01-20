import { Component } from '@angular/core';
import { MODES, SharedStateService } from '../shared-state.service';
import { Model } from '../../model/repository.model';
import { Product } from '../../model/product.model';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-table',
  imports: [CommonModule, RouterModule],
  templateUrl: './table.component.html',
  styleUrl: './table.component.css'
})
export class TableComponent {
  constructor(private model: Model, private state: SharedStateService) { }

  getProduct(key: number): Product | undefined {
    return this.model.getProduct(key);
  }
  getProducts(): Product[] {
    return this.model.getProducts();
  }

  deleteProduct(key?: number) {
    if (key != undefined) {
      this.model.deleteProduct(key);
    }
  }

  editProduct(key?: number) {
    this.state.update(MODES.EDIT, key)
  }

  createProduct() {
    this.state.update(MODES.CREATE)
  }


}
