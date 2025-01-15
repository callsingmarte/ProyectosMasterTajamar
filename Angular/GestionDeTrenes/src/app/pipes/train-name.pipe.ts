import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'trainName'
})
export class TrainNamePipe implements PipeTransform {

  transform(input: string | undefined): string {
    let name = input ?? "";
    let nameCapitalized = "";
    for (let index = 0; index < name.length; index++) {
      if (index == 0) {
        nameCapitalized = name[index].toUpperCase();
      } else {
        if (name[index - 1] == " ") {
          nameCapitalized += name[index].toUpperCase();
        } else {
          nameCapitalized += name[index]
        }
      }
    }

    return nameCapitalized;
  }

}
