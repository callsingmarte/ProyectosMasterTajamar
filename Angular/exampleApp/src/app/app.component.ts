import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { MessageComponent } from './messages/message/message.component';
import { TableComponent } from './core/table/table.component';
import { FormComponent } from './core/form/form.component';
import { ProductCountComponent } from './core/product-count/product-count.component';
import { CategoryCountComponent } from './core/category-count/category-count.component';
import { NotFoundComponent } from './core/not-found/not-found.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, MessageComponent,
    TableComponent, FormComponent, RouterModule,
    ProductCountComponent, CategoryCountComponent, NotFoundComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'exampleApp';
}

//WildCards: manejar rutas con error (**)
