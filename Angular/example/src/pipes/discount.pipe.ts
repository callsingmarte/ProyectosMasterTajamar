import { Pipe, PipeTransform } from '@angular/core';
import { DiscountService } from '../services/discount.service';

@Pipe({
  name: 'discount',
  pure: false //impura porque aplica a todos los prices
})
export class DiscountPipe implements PipeTransform {

  constructor(public discount: DiscountService) { }

  transform(price: number): number | undefined {
    return this.discount.applyDiscount(price);
  }

}
