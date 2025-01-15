import { Pipe, PipeTransform } from '@angular/core';
import { Train } from '../components/train.model';

@Pipe({
  name: 'trainFilter',
  pure: false
})
export class TrainFilterPipe implements PipeTransform {

  transform(trains: Train[] | undefined, name: string | undefined): Train[] {
    if (!trains) {
      return [];
    }

    if (!name || name.trim() === "" || name == undefined) {
      return trains;
    }

    const searchTerm = name.toLowerCase();

    return trains.filter(t => t.name?.toLowerCase().includes(searchTerm));
  }

}
