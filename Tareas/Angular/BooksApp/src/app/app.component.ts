import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BookFormComponent } from './components/book-form/book-form.component';
import { BookTableComponent } from './components/book-table/book-table.component';
import { Book } from './model/book.model';
import { BookList } from './model/bookList';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, BookFormComponent, BookTableComponent, BookList],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'BooksApp';

  books: Book[] = new Array<Book>;
  public bookList = new BookList()

}
