import { Pipe, PipeTransform } from '@angular/core';
import { Product } from '../app/product/product.model';

@Pipe({
  name: 'categoryFilter',
  pure: false
})
export class CategoryFilterPipe implements PipeTransform {

  transform(products: Product[] | undefined, category: string | undefined): Product[] {
    if (!products){
      return [];
    }

    if (category == 'None' || category === undefined) {
      return products;
    }

    return products.filter(p => p.category === category)

  }

}
