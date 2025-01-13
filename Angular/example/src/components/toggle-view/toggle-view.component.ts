import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-toggle-view',
  imports: [FormsModule, CommonModule],
  templateUrl: './toggle-view.component.html',
  styleUrl: './toggle-view.component.css'
})
export class ToggleViewComponent {
  showContent: boolean = true;

}
