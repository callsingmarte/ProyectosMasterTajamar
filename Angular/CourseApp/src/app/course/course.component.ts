import { ApplicationRef, Component } from '@angular/core';
import { Model } from './repository.model';
import { CommonModule } from '@angular/common';
import { Course } from './course.model';
import { FormsModule, NgForm, NgModel, ValidationErrors } from '@angular/forms';
import { CuAttrDirective } from '../directives/CuAttr.directive';
import { PaModel } from '../directives/twoway.directive';
import { CourseFormComponent } from '../components/course-form/course-form.component';
import { CourseTableComponent } from '../components/course-table/course-table.component';

@Component({
  selector: 'app-course',
  imports: [CommonModule, FormsModule, CuAttrDirective,
    PaModel, CourseFormComponent, CourseTableComponent],
  templateUrl: './course.component.html',
  styleUrl: './course.component.css'
})
export class CourseComponent {
  model: Model = new Model();
  constructor(ref: ApplicationRef) {
    if (typeof window !== 'undefined') {
      (<any>window).appRef = ref;
      (<any>window).model = this.model;
    }
  }
  getCourseByPosition(position: number): Course {
    return this.model.getCourses()[position];
  }
  getCourse(key: number): Course {
    return this.model.getCourse(key);
  }

  getCourses(): Course[] {
    return this.model.getCourses();
  }
  getCourseCount(): number {
    console.log("getCourseCount invoked");
    return this.getCourses().length;
  }
  targetName: string = "Kayak";
  getClassesMap(key: number): Object {
    let course = this.model.getCourse(key);
    return {
      "text-center bg-warning": course?.title == "Angular",
      "bg-info": course?.seatCapacity > 17
    };
  }
  getStyles(key: number) {
    let course = this.model.getCourse(key);
    return {
      "margin.px": 100,
      color: course?.seatCapacity >= 17 ? "green" : "red",
      fontSize: course?.title == "Angular" ? "30px" : "20px"
    };
  }

  selectedCourse: Course = new Course();

  newCourse: Course = new Course();

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
