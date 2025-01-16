import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MODES, SharedStateService } from '../shared-state.service';
import { Model } from '../../model/repository.model';
import { Course } from '../../model/course.model';

@Component({
  selector: 'app-table',
  imports: [CommonModule],
  templateUrl: './table.component.html',
  styleUrl: './table.component.css'
})
export class TableComponent {
  constructor(private model: Model, private state: SharedStateService) { }

  getCourse(key: number): Course {
    return this.model.getCourse(key);
  }

  getCourses(): Course[] {
    return this.model.getCourses();
  }

  deleteCourse(key?: number) {
    if (key != undefined) {
      this.model.deleteCourse(key);
    }
  }

  editCourse(key?: number) {
    this.state.update(MODES.EDIT, key)
  }

  createCourse() {
    this.state.update(MODES.CREATE)
  }
}
