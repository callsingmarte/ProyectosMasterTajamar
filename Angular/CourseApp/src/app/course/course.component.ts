import { ApplicationRef, Component } from '@angular/core';
import { Model } from './repository.model';
import { CommonModule } from '@angular/common';
import { Course } from './course.model';

@Component({
  selector: 'app-course',
  imports: [CommonModule],
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
}
