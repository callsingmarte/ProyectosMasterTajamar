import { Component, EventEmitter, Output } from '@angular/core';
import { Product } from '../product.model';
import { Model } from '../repository.model';
import { FormsModule, NgForm, NgModel, ValidationErrors } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { DiscountDisplayComponent } from '../../../components/discount-display/discount-display.component';
import { DiscountEditorComponent } from '../../../components/discount-editor/discount-editor.component';

@Component({
  selector: 'app-product-form',
  imports: [FormsModule, CommonModule, DiscountDisplayComponent, DiscountEditorComponent],
  templateUrl: './product-form.component.html',
  styleUrl: './product-form.component.css'
})
export class ProductFormComponent {
  newProduct: Product = new Product();
  //model: Model = new Model();
  formSubmitted: boolean = false;

  //@Output("paNewProduct")
  //newProductEvent = new EventEmitter<Product>

  constructor(public model:Model) { }

  getMessages(errs: ValidationErrors | null, name: string): string[] {
    let messages: string[] = [];

    for (let errorName in errs) {
      switch (errorName) {
        case "required":
          messages.push(`You must enter a ${name}`);
          break;
        case "minlength":
          messages.push(`A ${name} must be at least ${errs['minlength'].requiredLength} characters`);
          break;
        case "pattern":
          messages.push(`The ${name} contains illegal characters`);
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
      //this.newProductEvent.emit(this.newProduct);
      this.model.saveProduct(this.newProduct)
      this.newProduct = new Product();
      form.resetForm();
      this.formSubmitted = false;
    }
  }

  //addProduct(p: Product) {
  //  this.model.saveProduct(p);
  //}
}
