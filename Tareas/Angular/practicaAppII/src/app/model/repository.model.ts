import { Injectable } from "@angular/core";
import { StaticDataSource } from "./static.datasource";
import { Course } from "./course.model";

@Injectable({
  providedIn: 'root'
})

export class Model {
  private courses: Course[];
  private locator = (p: Course, id: number) => p.id == id;

  constructor(private dataSource: StaticDataSource) {
    this.courses = new Array<Course>();
    this.dataSource.getData().forEach(c => this.courses.push(c))
  }

  getCourses(): Course[] {
    return this.courses;
  }
  getCourse(id: number): any {
    return this.courses.find(p => this.locator(p, id));
  }
  saveCourse(course: any) {
    if (course.id == 0 || course.id == null) {
      course.id = this.generateID();
      this.courses.push(course);
    } else {
      let index = this.courses
        .findIndex(p => this.locator(p, course.id));
      this.courses.splice(index, 1, course);
    }
  }
  deleteCourse(id: number) {
    let index = this.courses.findIndex(p => this.locator(p, id));
    if (index > -1) {
      this.courses.splice(index, 1);
    }
  }
  private generateID(): number {
    let candidate = 100;
    while (this.getCourse(candidate) != null) {
      candidate++;
    }
    return candidate;
  }
}
