import { Pipe, PipeTransform } from '@angular/core';
import { FormControl, ValidationErrors } from '@angular/forms';

@Pipe({
  name: 'validationHelper'
})
export class ValidationHelperPipe implements PipeTransform {

  transform(source: any, name: any): string[] {
    if (source instanceof FormControl) {
      //devolver nuevo mensaje formateado con el nombre del control y error
      return this.formatMessages((source as FormControl).errors, name)
    }

    return this.formatMessages(source as ValidationErrors, name)
  }

  formatMessages(errors: ValidationErrors | null, name:string): string[] {
    let messages: string[] = [];
    for (let errorName in errors) {
      switch (errorName) {
        case "required":
          messages.push(`You must enter a ${name}`);
          break;
        case "minlength":
          messages.push(`A ${name} must be at least ${errors['minlength'].requiredLength} characters`);
          break;
        case "pattern":
          messages.push(`The ${name} contains illegal characters`);
          break;
      }
    }
    return messages;
  }

}
