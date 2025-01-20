import { Component } from '@angular/core';
import { FormArray, FormControl, FormGroup, FormsModule, NgForm, ReactiveFormsModule, Validators } from '@angular/forms';
import { Product } from '../../model/product.model';
import { Model } from '../../model/repository.model';
import { MODES, SharedStateService, StateUpdate } from '../shared-state.service';
import { MessageService } from '../../messages/message.service';
import { Message } from '../../messages/message.model';
import { CommonModule } from '@angular/common';
import { ValidationHelperPipe } from '../validation-helper.pipe';
import { ValidationErrorsDirective } from '../validation-errors.directive';
import { FilteredFormArray } from '../filteredFormArray';
import { LimitValidator } from '../../validation/limit';
import { HillowValidatorDirective } from '../../validation/hillow.directive';
import { ProhibitedValidator } from '../../validation/prohibited';
import { UniqueValidator } from '../../validation/unique';
import { ActivatedRoute, RouterModule } from '@angular/router';

@Component({
  selector: 'app-form',
  imports: [FormsModule, ReactiveFormsModule,
    ValidationHelperPipe, CommonModule,
    ValidationErrorsDirective, HillowValidatorDirective,
    RouterModule],
  templateUrl: './form.component.html',
  styleUrl: './form.component.css'
})
export class FormComponent {

  product: Product = new Product();
  editing: boolean = false;

  //keywordGroup = new FilteredFormArray([this.createKeywordFormControl()], {
  //  validators: UniqueValidator.unique()
  //});

  productForm: FormGroup = new FormGroup({
    name: new FormControl("", {
        validators: [
          Validators.required,
          Validators.minLength(3),
          Validators.pattern("^[A-Za-z ]+$")
      ],
      updateOn: "change"
    }),
    category: new FormControl("", {
      validators: Validators.required,
      asyncValidators: ProhibitedValidator.prohibited()
    }),
    price: new FormControl("", {
      validators: [
        Validators.required,
        Validators.pattern("^[0-9\.]+$"),
        LimitValidator.Limit(300)
      ]
    }),
  //  details: new FormGroup({
  //    supplier: new FormControl("", { validators: Validators.required }),
  //    keywords: this.keywordGroup,
  //  })
  })

  //private state: SharedStateService
  //private messageService: MessageService
  constructor(private model: Model, activeRoute: ActivatedRoute)
  {
    this.editing = activeRoute.snapshot.url[1].path == "edit";
    let id = activeRoute.snapshot.params["id"];

    if (id != null) {
      Object.assign(this.product, model.getProduct(id) || new Product());
      this.productForm.patchValue(this.product);
    }

  //  this.state.changes.subscribe((upd) => this.handleStateChange(upd))
  //  this.messageService.reportMessage(new Message("Creating new Product"));
  }

  //ngOnInit() {
  //  this.productForm.get('details')?.statusChanges.subscribe(newStatus => {
  //    this.messageService.reportMessage(new Message(`Details ${newStatus}`));
  //  })
  //}

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

  //handleStateChange(newState: StateUpdate) {
  //  this.editing = newState.mode == MODES.EDIT;
  //  this.keywordGroup.clear();
  //  if (this.editing && newState.id) {
  //    Object.assign(this.product, this.model.getProduct(newState.id) ?? new Product());
  //    this.messageService.reportMessage(new Message(`Editing ${this.product.name}`));
  //    this.product.details?.keywords?.forEach(() => {
  //      this.keywordGroup.push(this.createKeywordFormControl())
  //    })
  //  } else {
  //    this.product = new Product();
  //    this.messageService.reportMessage(new Message("Creating new product"));
  //  }
  //  if (this.keywordGroup.length == 0) {
  //    this.keywordGroup.push(this.createKeywordFormControl());
  //  }
  //  this.productForm.reset(this.product);
  //}
 
  submitForm(form: NgForm) {
    if (form.valid) {
      this.model.saveProduct(this.product);
      this.product = new Product();
      form.reset();
    }

  //  if (this.productForm.valid) {
  //    Object.assign(this.product, this.productForm.value);
  //    this.model.saveProduct(this.product);
  //    this.product = new Product()
  //    this.keywordGroup.clear();
  //    this.keywordGroup.push(this.createKeywordFormControl())
  //    this.productForm.reset();
  //  }
  }

  //resetForm() {
  //  this.editing = true;
  //  this.product = new Product();
  //  this.productForm.reset();
  //  this.keywordGroup.clear();
  //  this.keywordGroup.push(this.createKeywordFormControl())
  //}

  //addKeywordControl() {
  //  this.keywordGroup.push(this.createKeywordFormControl());
  //}

  //removeKeywordControl(index: number) {
  //  this.keywordGroup.removeAt(index);
  //}

  //createKeywordFormControl(): FormControl {
  //  return new FormControl("", { validators: Validators.pattern("^[A-Za-z ]+$") });
  //}

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
