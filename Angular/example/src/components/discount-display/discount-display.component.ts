import { Component, Input } from '@angular/core';
import { DiscountService } from '../../services/discount.service';

@Component({
  selector: 'app-discount-display',
  imports: [],
  template: `<div class="bg-info text-white p-2 my-2">
            The discount is {{discounter?.discount}}
            </div>
  `,
  styleUrl: './discount-display.component.css'
})
export class DiscountDisplayComponent {
  //  @Input("discounter")
  //  discounter?: DiscountService;+
  constructor(public discounter:DiscountService) {}
}
