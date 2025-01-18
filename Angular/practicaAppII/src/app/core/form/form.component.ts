import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Course } from '../../model/course.model';
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
  course: Course = new Course();
  editing: boolean = false;

  constructor(private model: Model, private state: SharedStateService,
    private messageService: MessageService) {
    this.state.changes.subscribe((upd) => this.handleStateChange(upd))
    this.messageService.reportMessage(new Message("Creating New Product"));
  }

  handleStateChange(newState: StateUpdate) {
    this.editing = newState.mode == MODES.EDIT;
    if (this.editing && newState.id) {
      Object.assign(this.course, this.model.getCourse(newState.id) ?? new Course());
      this.messageService.reportMessage(new Message(`Editing ${this.course.title}`));
    } else {
      this.course = new Course();
      this.messageService.reportMessage(new Message("Creating new Course"));
    }
  }

  submitForm(form: NgForm) {
    if (form.valid) {
      this.model.saveCourse(this.course);
      this.course = new Course();
      form.resetForm();
    } 
  }

}
