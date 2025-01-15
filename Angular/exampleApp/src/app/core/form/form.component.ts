import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Product } from '../../model/product.model';
import { Model } from '../../model/repository.model';
import { MODES, SharedStateService, StateUpdate } from '../shared-state.service';
import { MessageService } from '../../messages/message.service';
import { Message } from '../../messages/message.model';

@Component({
  selector: 'app-form',
  imports: [FormsModule],
  templateUrl: './form.component.html',
  styleUrl: './form.component.css'
})
export class FormComponent {

  product: Product = new Product();
  editing: boolean = false;

  constructor(private model: Model,
    private state: SharedStateService,
    private messageService: MessageService)
  {
    this.state.changes.subscribe((upd) => this.handleStateChange(upd))
    this.messageService.reportMessage(new Message("Creating new Product"));
  }

  handleStateChange(newState: StateUpdate) {
    this.editing = newState.mode == MODES.EDIT;
    if (this.editing && newState.id) {
      Object.assign(this.product, this.model.getProduct(newState.id) ?? new Product());
      this.messageService.reportMessage(new Message(`Editing ${this.product.name}`));
    } else {
      this.product = new Product();
      this.messageService.reportMessage(new Message("Creating new product"));
    }
  }

}
