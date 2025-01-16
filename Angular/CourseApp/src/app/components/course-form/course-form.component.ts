import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule, NgForm, NgModel, ValidationErrors } from '@angular/forms';
import { Course } from '../../course/course.model';
import { Model } from '../../course/repository.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-course-form',
  imports: [FormsModule, CommonModule],
  templateUrl: './course-form.component.html',
  styleUrl: './course-form.component.css'
})
export class CourseFormComponent {
  newCourse: Course = new Course();
  model: Model = new Model();
  formSubmitted: boolean = false;

  @Output("paNewCourse")
  newCourseEvent = new EventEmitter<Course>

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

  addCourse(course: Course) {
    this.model.saveCourse(course);
  }


  submitForm(form: NgForm) {
    this.formSubmitted = true;
    if (form.valid) {
      this.newCourseEvent.emit(this.newCourse);
      this.addCourse(this.newCourse);
      this.newCourse = new Course();
      form.resetForm();
      this.formSubmitted = false;
    }
  }

}
