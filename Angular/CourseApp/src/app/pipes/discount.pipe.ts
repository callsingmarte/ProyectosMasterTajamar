import { Pipe, PipeTransform } from '@angular/core';
import { DiscountService } from '../services/discount.service';

@Pipe({
  name: 'discount',
  pure: false
})
export class DiscountPipe implements PipeTransform {

  constructor(private discount: DiscountService) { }

  transform(price: number): number | undefined {
    return this.discount.applyDiscount(price);
  }

}
