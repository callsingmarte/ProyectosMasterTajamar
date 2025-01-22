import { Observable, ReplaySubject } from "rxjs";
import { Product } from "./product.model";
import { RestDataSource } from "./rest.datasource";
import { StaticDataSource } from "./static.datasource";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})

export class Model {
  //private dataSource: SimpleDataSource;
  private products: Product[] = new Array<Product>;
  private locator = (p: Product, id: number) => p.id == id;
  private replaySubject: ReplaySubject<Product[]>
  constructor(private dataSource: RestDataSource) {
    //this.products = new Array<Product>();
    //El 1 indica que recupere lo ultimo que tenia en el buffer
    this.replaySubject = new ReplaySubject<Product[]>(1);
    this.dataSource.getData().subscribe(data => {
      this.products = data
      this.replaySubject.next(data);
      this.replaySubject.complete();
    });
  }
  getProducts(): Product[] {
    return this.products;
  }
  getProduct(id: number): any {
    return this.products.find(p => this.locator(p, id));
  }

  getProductObservable(id: number): Observable<Product | undefined> {
    let subject = new ReplaySubject<Product | undefined>(1);
    this.replaySubject.subscribe(products => {
      subject.next(products.find(p => this.locator(p, id)));
      subject.complete();
    })
    return subject;
  }

  getNextProductId(id?: number): Observable<number> {
    let subject = new ReplaySubject<number>(1);
    this.replaySubject.subscribe(products => {
      let nextId = 0;
      let index = products.findIndex(p => this.locator(p, id ?? 0));
      if (index > -1) {
        nextId = products[products.length > index + 1 ? index + 1 : 0].id ?? 0;
      } else {
        nextId = id || 0;
      }
      subject.next(nextId);
      subject.complete();
    })
    return subject;
  }

  getPreviousProductId(id?: number):Observable<number> {
    let subject = new ReplaySubject<number>(1);
    this.replaySubject.subscribe(products => {
      let prevId = 0;
      let index = products.findIndex(p => this.locator(p, id ?? 0));
      if (index > -1) {
        prevId = products[index > 0 ? index - 1 : products.length - 1].id ?? 0;
      } else {
        prevId = id || 0;
      }
      subject.next(prevId);
      subject.complete();
    });
    return subject;
  }

  saveProduct(product: any) {
    if (product.id == 0 || product.id == null) {
      this.dataSource.saveProduct(product).subscribe(p => this.products.push(p))
    } else {
      this.dataSource.updateProduct(product).subscribe(p => {
        let index = this.products.findIndex(item => this.locator(item, p.id!))
        this.products.splice(index, 1, p)
      })
    }
  }
  deleteProduct(id: number) {
    this.dataSource.deleteProduct(id).subscribe(() => {
      let index = this.products.findIndex(p => this.locator(p, id));
      if (index > -1) {
        this.products.splice(index, 1);
      }
    })
  }

//  private generateID(): number {
//    let candidate = 100;
//    while (this.getProduct(candidate) != null) {
//      candidate++;
//    }
//    return candidate;
//  }
}
