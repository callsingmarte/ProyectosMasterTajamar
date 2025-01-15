import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule, NgForm, NgModel, ValidationErrors } from '@angular/forms';
import { Course } from '../../course/course.model';

@Component({
  selector: 'app-course-form',
  imports: [FormsModule],
  templateUrl: './course-form.component.html',
  styleUrl: './course-form.component.css'
})
export class CourseFormComponent {
  newCourse: Course = new Course();

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

  formSubmitted: boolean = false;

  get jsonCourse() {
    return JSON.stringify(this.newCourse);
  }

  addCourse(course: Course) {
    console.log("New Course: " + this.jsonCourse);
  }

  submitForm(form: NgForm) {
    this.formSubmitted = true;
    if (form.valid) {
      this.addCourse(this.newCourse);
      this.newCourse = new Course();
      form.resetForm();
      this.formSubmitted = false;
    }
  }

}
