import { Component, Input, LOCALE_ID } from '@angular/core';
import { Model } from '../repository.model';
import { Product } from '../product.model';
import { CommonModule } from '@angular/common';
import { PaIteratorDirective } from '../../../directives/iterator.directive';
import { AddTaxPipe } from '../../../pipes/add-tax.pipe';
import { CategoryFilterPipe } from '../../../pipes/category-filter.pipe';
import { FormsModule } from '@angular/forms';
import { registerLocaleData } from '@angular/common';
import localeEs from '@angular/common/locales/es';
import { Subject } from 'rxjs';
import { DiscountDisplayComponent } from '../../../components/discount-display/discount-display.component';
import { DiscountEditorComponent } from '../../../components/discount-editor/discount-editor.component';
import { DiscountService } from '../../../services/discount.service';
import { DiscountPipe } from '../../../pipes/discount.pipe';
import { DiscountAmountDirective } from '../../../directives/discount-amount.directive';

registerLocaleData(localeEs, 'es');


@Component({
  selector: 'app-product-table',
  imports: [PaIteratorDirective, CommonModule, AddTaxPipe,
    CategoryFilterPipe, FormsModule,
    DiscountDisplayComponent, DiscountEditorComponent,
    DiscountPipe, DiscountAmountDirective
  ],
  templateUrl: `./product-table.component.html`,
  styleUrl: './product-table.component.css',
  providers: [{provide:LOCALE_ID, useValue: 'es'}]
})
export class ProductTableComponent {
  //discounter: DiscountService = new DiscountService();

  constructor(public dataModel: Model) { }

  //@Input("model")
  //dataModel: Model | undefined;

  getProduct(key: number): Product | undefined {
    return this.dataModel?.getProduct(key);
  }

  getProducts(): Product[] | undefined {
    return this.dataModel?.getProducts();
  }

  deleteProduct(key: number) {
    this.dataModel?.deleteProduct(key);
  }

  //showTable: boolean = true;

  //taxRate: number = 0;
  //categoryFilter: string | undefined;
  //itemCount: number = 3;

  //dateObject: Date = new Date(2020, 1, 20);
  //dateString: string = "2020-02-20T00:00:00.000Z";
  //dateNumber: number = 1582156800000;

  //numbers: Subject<number> = new Subject<number>();

  //ngOnInit() {
  //  let counter = 10;
  //  setInterval(() => {
  //     this.numbers.next(counter += 10)
  //  }, 4000)
  //}
}
