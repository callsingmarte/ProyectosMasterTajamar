import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule, NgForm, ReactiveFormsModule, Validators } from '@angular/forms';
import { Product } from '../../model/product.model';
import { Model } from '../../model/repository.model';
import { MODES, SharedStateService, StateUpdate } from '../shared-state.service';
import { MessageService } from '../../messages/message.service';
import { Message } from '../../messages/message.model';
import { CommonModule } from '@angular/common';
import { ValidationHelperPipe } from '../validation-helper.pipe';
import { ValidationErrorsDirective } from '../validation-errors.directive';

@Component({
  selector: 'app-form',
  imports: [FormsModule, ReactiveFormsModule,
    ValidationHelperPipe, CommonModule, ValidationErrorsDirective],
  templateUrl: './form.component.html',
  styleUrl: './form.component.css'
})
export class FormComponent {

  product: Product = new Product();
  editing: boolean = false;

  productForm: FormGroup = new FormGroup({
    name: new FormControl("", {
        validators: [
          Validators.required,
          Validators.minLength(3),
          Validators.pattern("^[A-Za-z ]+$")
      ],
      updateOn: "change"
    }),
    category: new FormControl("", { validators: Validators.required }),
    price: new FormControl("", {
      validators: [
        Validators.required,
        Validators.pattern("^[0-9\.]+$")
      ]
    })
  })

  constructor(private model: Model,
    private state: SharedStateService,
    private messageService: MessageService)
  {
    this.state.changes.subscribe((upd) => this.handleStateChange(upd))
    this.messageService.reportMessage(new Message("Creating new Product"));
  }

  //ngOnInit() {
  //  //comprueba cambios de valor en el namefield
  //  //this.namefield.valueChanged
  //  //Estos son los 4 estados posibles 
  //  //VALID, INVALID, PENDING, DISABLED  
  //  this.productForm.statusChanges.subscribe(newStatus => {
  //    if (newStatus === "INVALID") {
  //      let invalidControls: string[] = [];
  //      for (let controlName in this.productForm.controls) {
  //        if (this.productForm.controls[controlName].invalid) {
  //          invalidControls.push(controlName);
  //        }
  //      }
  //      this.messageService.reportMessage(new Message(`INVALID: ${invalidControls.join(",")}`))
  //    } else {
  //      this.messageService.reportMessage(new Message(newStatus))
  //    }
  //  });
  //}

  handleStateChange(newState: StateUpdate) {
    this.editing = newState.mode == MODES.EDIT;
    if (this.editing && newState.id) {
      Object.assign(this.product, this.model.getProduct(newState.id) ?? new Product());
      this.messageService.reportMessage(new Message(`Editing ${this.product.name}`));
    } else {
      this.product = new Product();
      this.messageService.reportMessage(new Message("Creating new product"));
    }
    this.productForm.reset(this.product);
  }
 
  submitForm() {
    if (this.productForm.valid) {
      Object.assign(this.product, this.productForm.value);
      this.model.saveProduct(this.product);
      this.product = new Product()
      this.productForm.reset();
    }
  }

  resetForm() {
    this.editing = true;
    this.product = new Product();
    this.productForm.reset();
  }

  //submitForm(form: NgForm) {
  //  if (form.valid) {
  //    this.model.saveProduct(this.product);
  //    this.product = new Product();
  //    form.resetForm();
  //  }else {
  //    console.log("Formulario no es valido");
  //  }
  //}
}
