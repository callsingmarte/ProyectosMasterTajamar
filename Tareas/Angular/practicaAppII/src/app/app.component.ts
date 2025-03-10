import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { MessageComponent } from './messages/message/message.component';
import { TableComponent } from './core/table/table.component';
import { FormComponent } from './core/form/form.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, MessageComponent,
    TableComponent, FormComponent, RouterModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'practicaAppII';
}
