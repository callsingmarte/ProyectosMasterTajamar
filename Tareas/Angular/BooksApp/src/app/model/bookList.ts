import { Injectable } from "@angular/core";
import { Book } from "./book.model";

@Injectable({
  providedIn: 'root'
})

export class BookList {

  constructor(public user: string, private books: Book[] = []) {
  }

  getBooks(): Book[] {
    return this.books;
  }

  getBook(title: string): any {
    return this.books.find(b => b.title == title)
  }

  saveBook(title: string) {
    this.books.push(new Book(title));
  }

  deleteBook(title: string) {
    let index = this.books.findIndex(b => b.title == title);
    if (index > -1) {
      this.books.splice(index, 1);
    }
  }

  private generateID() : number {
    let candidate = this.books.length;
    while (this.getBook(candidate) != null) {
      candidate++;
    }

    return candidate;
  }
}
