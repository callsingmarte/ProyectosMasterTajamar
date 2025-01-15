import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'trainStatus'
})
export class TrainStatusPipe implements PipeTransform {

  transform(departure: Date | undefined): string {
    const currentDate = new Date();
    const departDate = departure ?? new Date();
    return departDate.getTime() > currentDate.getTime() ? 'On Time' : 'Departed';
  }
}
