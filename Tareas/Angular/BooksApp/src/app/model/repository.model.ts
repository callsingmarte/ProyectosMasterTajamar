import { Injectable } from "@angular/core";
import { Book } from "./book.model";
import { SimpleDataSource } from "./datasource.model";

@Injectable({
  providedIn: 'root'
})

export class Model {

  private books: Book[];
  public author: string = "Martin";
  constructor(public dataSource: SimpleDataSource) {
    this.dataSource = new SimpleDataSource();
    this.books = new Array<Book>();
    this.dataSource.getData().forEach(b => this.books.push(b))
  }

  get Author() {
    return this.author;
  }

  set Author(name: string) {
    this.author = name;
  }

  getBooks(): Book[] {
    return this.books;
  }

  getBook(title: string): any {
    return this.books.find(b => b.title == title)
  }

  addBook(title: string) {
    if (this.getBook(title).title != title) {
      this.books.push(new Book(title));
    }
  }

  deleteBook(title: string) {
    let index = this.books.findIndex(b => b.title == title);
    if (index > -1) {
      this.books.splice(index, 1);
    }
  }
}
