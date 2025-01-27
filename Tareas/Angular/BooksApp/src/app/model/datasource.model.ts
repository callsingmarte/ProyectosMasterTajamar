import { Injectable } from "@angular/core";
import { Book } from "./book.model";

@Injectable({
  providedIn: 'root'
})

export class SimpleDataSource {
  private data: Book[];
  constructor() {
    this.data = new Array<Book>(
      new Book("El Quijote"),
      new Book("The Witcher", true)
    )
  }

  getData(): Book[] {
    return this.data;
  }
}
