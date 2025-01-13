import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'addTax'
})
export class AddTaxPipe implements PipeTransform {

  defaultRate: number = 10;
  transform(value: any, rate?: any): number {
    let valueNumber = Number.parseFloat(value);
    let rateNumber = rate == undefined ? this.defaultRate : Number.parseInt(rate);

    let returnValue = valueNumber + (valueNumber * (rateNumber / 100));

    return parseFloat(returnValue.toFixed(2));
  }

}
