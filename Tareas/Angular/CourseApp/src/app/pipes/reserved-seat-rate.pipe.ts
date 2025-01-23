import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'reservedSeatRate'
})
export class ReservedSeatRatePipe implements PipeTransform {

  defaultRate: number = 10;

  transform(value: any, rate?: any): number {
    let valueNumber = Number.parseInt(value);
    let rateNumber = rate == undefined ? this.defaultRate : Number.parseInt(rate);
    let returnValue = valueNumber + (valueNumber * (rateNumber / 100));
    return parseInt(returnValue.toString())
  }

}
