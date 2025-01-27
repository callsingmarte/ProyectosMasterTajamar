import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BookFormComponent } from './components/book-form/book-form.component';
import { BookTableComponent } from './components/book-table/book-table.component';
import { Model } from './model/repository.model';
import { SimpleDataSource } from './model/datasource.model';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, BookFormComponent, BookTableComponent],
  templateUrl: './app.component.html',
  providers: [Model, SimpleDataSource],
  styleUrl: './app.component.css'
})
export class AppComponent {
  constructor(public model: Model) {
    this.model = new Model(new SimpleDataSource());
  }

}
