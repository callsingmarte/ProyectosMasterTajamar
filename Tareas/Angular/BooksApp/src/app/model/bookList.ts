import { Injectable } from "@angular/core";
import { Book } from "./book.model";

@Injectable({
  providedIn: 'root'
})

export class BookList {

  private books = [new Book("Don quijote", false), new Book("The witcher", true)];

  getBooks(): Book[] {
    return this.books;
  }

  getBook(title: string): any {
    return this.books.find(b => b.title == title)
  }

  addBook(title: string) {
    this.books.push(new Book(title));
  }

  deleteBook(title: string) {
    let index = this.books.findIndex(b => b.title == title);
    if (index > -1) {
      this.books.splice(index, 1);
    }
  }
}
