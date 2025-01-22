import { Component, Input } from '@angular/core';
import { BookList } from '../../model/bookList';
import { Book } from '../../model/book.model';
import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-book-table',
  imports: [MatTableModule, MatCheckboxModule, MatButtonModule, FormsModule ],
  templateUrl: './book-table.component.html',
  styleUrl: './book-table.component.css'
})
export class BookTableComponent {
  @Input("BookList")
  bookList: BookList | undefined

  private books = new Array<Book>

  ngOnInit() {
    this.books = this.bookList!.getBooks();
  }
}
