import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { CourseComponent } from './app/course/course.component';

bootstrapApplication(CourseComponent, appConfig)
  .catch((err) => console.error(err));
