import { Directive, Input, KeyValueDiffer, KeyValueDiffers, SimpleChange } from '@angular/core';
import { DiscountService } from '../services/discount.service';

@Directive({
  selector: 'td[appDiscountAmount]',
  exportAs: "discount"
})
export class DiscountAmountDirective {

  private differ?: KeyValueDiffer<any, any>;
  constructor(private keyValueDiffers: KeyValueDiffers, private discount: DiscountService) { }

  @Input("appDiscountAmount")
  originalPrice?: number;

  discountAmount?: number;

  ngOnInit() {
    this.differ = this.keyValueDiffers.find(this.discount).create();
  }

  ngOnChanges(changes: { [property: string]: SimpleChange }) {
    if (changes["originalPrice"] != null) {
      this.updateValue();
    }
  }

  ngDoCheck() {
    if (this.differ?.diff(this.discount) != null) {
      this.updateValue();
    }
  }

  updateValue() {
    this.discountAmount = this.discount.applyDiscount(this.originalPrice ?? 0)
  }
}
