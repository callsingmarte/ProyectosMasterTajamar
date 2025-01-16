import { Component, Input } from '@angular/core';
import { CuAttrDirective } from '../../directives/CuAttr.directive';
import { CommonModule } from '@angular/common';
import { Course } from '../../course/course.model';
import { Model } from '../../course/repository.model';

@Component({
  selector: 'app-course-table',
  imports: [CuAttrDirective, CommonModule],
  templateUrl: './course-table.component.html',
  styleUrl: './course-table.component.css'
})
export class CourseTableComponent {
  selectedCourse: Course = new Course();

  @Input("model")
  model: Model = new Model();

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

  getInstructorsList() : string[] {

    let instructors: string[] = new Array();
    //TODO
    for (let course of this.getCourses()) {
      instructors.push(course.instructorName!);

    }


    return [""]
  }

}
