import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { DiscountService } from '../../services/discount.service';

@Component({
  selector: 'app-discount-editor',
  imports: [FormsModule],
  template: `
            <div class="form-group">
            <label>Discount</label>
            <input [(ngModel)]="discounter!.discount" class="form-control" type="number">
            </div>
            `,
  styleUrl: './discount-editor.component.css'
})
export class DiscountEditorComponent {
  constructor(public discounter: DiscountService) { }

//  @Input("discounter")
//  discounter?: DiscountService;
}
