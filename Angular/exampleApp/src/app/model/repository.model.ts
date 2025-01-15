import { Product } from "./product.model";
import { StaticDataSource } from "./static.datasource";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})

export class Model {
  //private dataSource: SimpleDataSource;
  private products: Product[];
  private locator = (p: Product, id: number) => p.id == id;
  constructor(private dataSource: StaticDataSource) {
    this.products = new Array<Product>();
    this.dataSource.getData().forEach(p => this.products.push(p));
  }
  getProducts(): Product[] {
    return this.products;
  }
  getProduct(id: number): any {
    return this.products.find(p => this.locator(p, id));
  }
  saveProduct(product: any) {
    if (product.id == 0 || product.id == null) {
      product.id = this.generateID();
      this.products.push(product);
    } else {
      let index = this.products
        .findIndex(p => this.locator(p, product.id));
      this.products.splice(index, 1, product);
    }
  }
  deleteProduct(id: number) {
    let index = this.products.findIndex(p => this.locator(p, id));
    if (index > -1) {
      this.products.splice(index, 1);
    }
  }
  private generateID(): number {
    let candidate = 100;
    while (this.getProduct(candidate) != null) {
      candidate++;
    }
    return candidate;
  }
}
