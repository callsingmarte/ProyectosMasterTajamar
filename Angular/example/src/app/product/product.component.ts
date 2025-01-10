import { ApplicationRef, Component } from "@angular/core";
import { Model } from "./repository.model";
import { CommonModule } from '@angular/common';
import { Product } from "./product.model";
import { FormsModule, NgForm, NgModel, ValidationErrors } from "@angular/forms";
import { PaAttrDirective } from "../directives/attr.directive";
import { PaModel } from "../directives/twoway.directive";
import { PaStructureDirective } from "../directives/structure.directive";
import { PaIteratorDirective } from "../directives/iterator.directive";
import { PaCellColor } from "../directives/cellColor.directive";
import { PaCellColorSwitcher } from "../directives/cellColorSwitcher.directive";
@Component({
  selector: "app-product",
  imports: [CommonModule, FormsModule, PaAttrDirective,
    PaModel, PaStructureDirective, PaIteratorDirective,
    PaCellColor, PaCellColorSwitcher], // Importa CommonModule aquí
  standalone: true, //Para corregir el error de cuando se usa el ngModel
  templateUrl: "./product.component.html"
})
export class ProductComponent {
  model: Model = new Model();
  showTable: boolean = false;
  darkColor: boolean = false;

  getProductByPosition(position: number): Product {
    return this.model.getProducts()[position];
  }
  getProduct(key: number): Product | undefined {
    return this.model.getProduct(key);
  }

  getProducts(): Product[] {
    return this.model.getProducts();
  }

  newProduct: Product = new Product();

  addProduct(p: Product) {
    this.model.saveProduct(p);
  }

  getMessages(errs: ValidationErrors | null, name:string): string[] {
    let messages: string[] = [];

    for (let errorName in errs){
      switch (errorName) {
        case "required":
          messages.push(`You must enter a ${name}`);
          break;
        case "minlength":
          messages.push(`A ${name} must be at least ${ errs['minlength'].requiredLength } characters`);
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

  formSubmitted: boolean = false;

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
      this.addProduct(this.newProduct);
      this.newProduct = new Product();
      form.resetForm();
      this.formSubmitted = false;
    }
  }

  deleteProduct(key: number)
  {
    this.model.deleteProduct(key);
  }

}
