import { ApplicationRef, Component } from "@angular/core";
import { Model } from "./repository.model";
import { CommonModule } from '@angular/common';
import { Product } from "./product.model";
@Component({
  selector: "app-product",
  imports: [CommonModule], // Importa CommonModule aquí
  templateUrl: "./product.component.html"
})
export class ProductComponent {
  model: Model = new Model();
  constructor(ref: ApplicationRef) {
    if (typeof window !== 'undefined') {
      (<any>window).appRef = ref;
      (<any>window).model = this.model;
    }
  }
  getProductByPosition(position: number): Product {
    return this.model.getProducts()[position];
  }
  getProduct(key: number): Product {
    return this.model.getProduct(key);
  }

  getProducts(): Product[] {
    return this.model.getProducts();
  }
  getProductCount(): number {
    console.log("getProductCount invoked");
    return this.getProducts().length;
  }
  targetName: string = "Kayak";
}
