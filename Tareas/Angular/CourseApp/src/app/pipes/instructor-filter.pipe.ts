import { Pipe, PipeTransform } from '@angular/core';
import { Course } from '../course/course.model';

@Pipe({
  name: 'instructorFilter',
  pure: false
})
export class InstructorFilterPipe implements PipeTransform {

  transform(courses: Course[] | undefined, instructor: string | undefined): Course[] {

    if (!courses) {
      return []
    }

    if (instructor == 'None' || instructor === undefined) {
      return courses
    }

    return courses.filter(c => c.instructorName == instructor)
  }

}
