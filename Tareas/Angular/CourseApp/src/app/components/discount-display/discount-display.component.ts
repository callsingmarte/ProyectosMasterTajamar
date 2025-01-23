import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { DiscountService } from '../../services/discount.service';

@Component({
  selector: 'app-discount-display',
  imports: [FormsModule],
  template: `<div class="bg-info text-white p-2 my-2">
              The discount is {{discounter?.discount}}
              </div>`,
  styleUrl: './discount-display.component.css'
})
export class DiscountDisplayComponent {
  constructor(public discounter: DiscountService) { }

//  @Input("discounter")
//  discounter?: DiscountService
}
