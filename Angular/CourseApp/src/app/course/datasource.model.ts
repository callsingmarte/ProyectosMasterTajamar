import { Course } from "./course.model";
export class SimpleDataSource {
  private data: Course[];
  constructor() {
    this.data = new Array<Course>(
      new Course(1, "Agile", 20, "Jhon Jones"),
      new Course(2, "C#", 15, "Jhon Jones"),
      new Course(3, "Angular", 13, "Ross Miller"),
      new Course(4, "Java", 10, "Alex Walker"));
  }
  getData(): Course[] {
    return this.data;
  }
}
