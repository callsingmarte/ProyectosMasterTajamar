import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { BookList } from '../../model/bookList';

@Component({
  selector: 'app-book-form',
  imports: [FormsModule, MatButtonModule, MatFormFieldModule, MatInputModule],
  templateUrl: './book-form.component.html',
  styleUrl: './book-form.component.css'
})
export class BookFormComponent {
  @Input("BookList")
  bookList: BookList | undefined

  addBook(newBook: string) {
    if (newBook != "") {
      this.bookList?.addBook(newBook);
    }
  }
}
