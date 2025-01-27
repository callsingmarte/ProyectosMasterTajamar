import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Model } from '../../model/repository.model';
import { SimpleDataSource } from '../../model/datasource.model';

@Component({
  selector: 'app-book-form',
  imports: [FormsModule, MatButtonModule, MatFormFieldModule, MatInputModule],
  templateUrl: './book-form.component.html',
  styleUrl: './book-form.component.css'
})
export class BookFormComponent {

  @Input("model")
  model: Model  = new Model(new SimpleDataSource());

  addBook(title:string) {
    this.model.addBook(title);
  }
}
