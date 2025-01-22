import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TodoList } from '../tasks/todoList';
import { TodoItem } from '../tasks/todoItem';
import { FormsModule } from '@angular/forms';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatBadgeModule } from '@angular/material/badge';
import { MatInputModule } from '@angular/material/input';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, FormsModule,
    MatButtonModule, MatToolbarModule, MatIconModule, MatBadgeModule,
    MatTableModule, MatCheckboxModule, MatFormFieldModule, MatInputModule,
    MatSlideToggleModule
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'todo';

  private list = new TodoList("Javier", [
    new TodoItem("Go for run", true),
    new TodoItem("Get flowers"),
    new TodoItem("Collect tickets"),
  ])

  get username(): string {
    return this.list.user;
  }

  get itemCount(): number {
    return this.list.items.filter(item => !item.complete).length;
  }

  get items(): readonly TodoItem[] {
    return this.list.items.filter(item => this.showComplete || !item.complete);
  }

  addItem(newItem: string) {
    if (newItem != "") {
      this.list.addItem(newItem);
    }
  }

  showComplete: boolean = false;

}
