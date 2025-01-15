import { Component, Input } from '@angular/core';
import { DiscountService } from '../../services/discount.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-discount-editor',
  imports: [FormsModule],
  template: `<div class="form-group">
              <label>Discount</label>
              <input class="form-control" type="number"
              [(ngModel)]=discounter!.discount
              >
             </div>`,
  styleUrl: './discount-editor.component.css'
})
export class DiscountEditorComponent {
  //@Input("discounter")
  //discounter?: DiscountService;
  constructor(public discounter: DiscountService) { }
}
