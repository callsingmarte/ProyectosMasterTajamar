import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TrainListComponent } from './components/train-list/train-list.component';
import { Model } from './components/repository.model';
import { TrainFormComponent } from './components/train-form/train-form.component';
import { Train } from './components/train.model';
import { HeaderComponent } from './components/header/header.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TrainListComponent, TrainFormComponent, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'GestionDeTrenes';
  model: Model = new Model();
  trainToEdit: Train | null = null;
  cancelEditField: boolean = false;

  addTrain(t: Train) {
    this.model.saveTrain(t);
    this.cancelEdit();
  }

  onEdit(train: Train) {
    console.log("editando")
    this.trainToEdit = train;
    this.cancelEditField = false;
  }

  cancelEdit() {
    console.log("cancelando")
    this.trainToEdit = null;
    this.cancelEditField = true;
  }
}
