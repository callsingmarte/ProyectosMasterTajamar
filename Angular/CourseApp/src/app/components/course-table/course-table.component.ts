import { Component, Input } from '@angular/core';
import { CuAttrDirective } from '../../directives/CuAttr.directive';
import { CommonModule } from '@angular/common';
import { Course } from '../../course/course.model';
import { Model } from '../../course/repository.model';
import { InstructorFilterPipe } from '../../pipes/instructor-filter.pipe';
import { FormsModule } from '@angular/forms';
import { ReservedSeatRatePipe } from '../../pipes/reserved-seat-rate.pipe';
import { DiscountDisplayComponent } from '../discount-display/discount-display.component';
import { DiscountEditorComponent } from '../discount-editor/discount-editor.component';
//import { DiscountService } from '../../services/discount.service';
import { DiscountPipe } from '../../pipes/discount.pipe';
import { DiscountAmountDirective } from '../../directives/discount-amount.directive';

@Component({
  selector: 'app-course-table',
  imports: [CuAttrDirective, FormsModule, CommonModule,
    InstructorFilterPipe, ReservedSeatRatePipe,
    DiscountDisplayComponent, DiscountEditorComponent,
    DiscountPipe, DiscountAmountDirective
  ],
  templateUrl: './course-table.component.html',
  styleUrl: './course-table.component.css'
})
export class CourseTableComponent {
  selectedCourse: Course = new Course();
  instructorFilter: string = "None";
  reservedSeatRate: number = 0;
  //discounter: DiscountService = new DiscountService();
  //@Input("model")
  //model: Model = new Model();

  constructor(private model: Model) { }

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
    let instructors: Set<string> = new Set();

    for (let course of this.getCourses()) {
      instructors.add(course.instructorName!);
    }

    let list: string[] = Array.from(instructors);

    list.unshift("None");

    return list;
  }

}
