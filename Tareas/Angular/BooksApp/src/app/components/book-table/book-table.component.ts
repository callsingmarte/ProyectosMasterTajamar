import { Component, Inject, Injectable, Input } from '@angular/core';
import { Book } from '../../model/book.model';
import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { Model } from '../../model/repository.model';
import { SimpleDataSource } from '../../model/datasource.model';

@Component({
  selector: 'app-book-table',
  imports: [MatTableModule, MatCheckboxModule, MatButtonModule, FormsModule ],
  templateUrl: './book-table.component.html',
  styleUrl: './book-table.component.css'
})
export class BookTableComponent {

  @Input("model")
  public model: Model = new Model(new SimpleDataSource());

  public books : Book[] = new Array<Book>();

  ngOnInit() {
    this.books = this.model.getBooks()
  }

}
