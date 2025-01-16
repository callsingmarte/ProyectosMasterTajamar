import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'reservedSeatRate'
})
export class ReservedSeatRatePipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }

}
