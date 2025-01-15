import { Component, ElementRef, EventEmitter, Input, Output, SimpleChanges, ViewChild } from '@angular/core';
import { Train } from '../train.model';
import { Model } from '../repository.model';
import { FormsModule, NgForm, NgModel, ValidationErrors } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-train-form',
  imports: [FormsModule, CommonModule],
  templateUrl: './train-form.component.html',
  styleUrl: './train-form.component.css'
})
export class TrainFormComponent {
  newTrain: Train = new Train();
  model: Model = new Model();
  formSubmitted: boolean = false;

  @Output("paNewTrain")
  newTrainEvent = new EventEmitter<Train>

  @Input()
  trainToEdit: Train | null = null;

  @Input()
  cancelEdit: boolean = false;

  @ViewChild("departureInput")
  departureInput!: ElementRef;


  getMessages(errs: ValidationErrors | null, name: string): string[] {
    let messages: string[] = [];

    for (let errorName in errs) {
      switch (errorName) {
        case "required":
          messages.push(`Debes introducir un ${name}`);
          break;
        case "minlength":
          messages.push(`El campo ${name} debe tener al menos ${errs['minlength'].requiredLength} caracteres`);
          break;
        case "pattern":
          messages.push(`El campo ${name} contiene caracteres no validos`);
          break;
      }
    }

    return messages;
  }

  getValidationMessages(state: NgModel, thingName?: string) {
    let thing: string = state.path[0] ?? thingName;
    return this.getMessages(state.errors, thing);
  }

  getFormValidationMessages(form: NgForm): string[] {
    let messages: string[] = [];
    Object.keys(form.controls).forEach(k => {
      this.getMessages(form.controls[k].errors, k)
        .forEach(m => messages.push(m));
    });
    return messages;
  }

  submitForm(form: NgForm) {
    this.formSubmitted = true;
    if (form.valid) {
      this.newTrainEvent.emit(this.newTrain);
      this.newTrain = new Train();
      form.resetForm();
      this.formSubmitted = false;
      this.cancelEdit = false;
      this.trainToEdit = null;
    }
  }

  addTrain(t: Train) {
    this.model.saveTrain(t);
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['trainToEdit'] && this.trainToEdit) {
      this.newTrain = this.trainToEdit;
      this.departureInput.nativeElement.value = this.newTrain.departure?.toDateString();
    }

    if (changes['cancelEdit'] && this.cancelEdit) {
      console.log("cancelEdit");
      this.newTrain = new Train();
      this.trainToEdit = null;
      this.cancelEdit = false;
    }
  }
}
