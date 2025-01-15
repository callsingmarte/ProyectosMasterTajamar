import { Course } from "./course.model";
export class SimpleDataSource {
  private data: Course[];
  constructor() {
    this.data = new Array<Course>(
      new Course(1, "Agile", 20, "Jhon Jones", 274),
      new Course(2, "C#", 15, "Jhon Jones", 345.23),
      new Course(3, "Angular", 13, "Ross Miller", 452),
      new Course(4, "Java", 10, "Alex Walker", 232.2));
  }
  getData(): Course[] {
    return this.data;
  }
}
