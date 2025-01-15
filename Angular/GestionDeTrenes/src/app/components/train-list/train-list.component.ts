import { Component, EventEmitter, Input, LOCALE_ID, Output } from '@angular/core';
import { Model } from '../repository.model';
import { Train } from '../train.model';
import { CommonModule, registerLocaleData } from '@angular/common';
import localeEs from '@angular/common/locales/es';
//import { Subject } from 'rxjs';
import { TrainStatusPipe } from '../../pipes/train-status.pipe';
import { TrainNamePipe } from '../../pipes/train-name.pipe';
import { TrainFilterPipe } from '../../pipes/train-filter.pipe';
import { FormsModule } from '@angular/forms';
import { HighlightDirective } from '../../directives/highlight.directive';

registerLocaleData(localeEs, 'es');

@Component({
  selector: 'app-train-list',
  imports: [CommonModule, TrainStatusPipe, TrainNamePipe, TrainFilterPipe,
    FormsModule, HighlightDirective],
  templateUrl: './train-list.component.html',
  styleUrl: './train-list.component.css',
  providers: [{ provide: LOCALE_ID, useValue: 'es' }]
})
export class TrainListComponent {
  @Input("model")
  dataModel: Model | undefined;

  trainFilter: string | undefined;

  selectedTrain: Train | null = null;

  @Output("onEdit") onEdit = new EventEmitter<Train>();
  @Output("onCancelEdit") onCancelEdit = new EventEmitter<null>();

  getTrain(key: number): Train | undefined {
    return this.dataModel?.getTrain(key);
  }

  getTrains(): Train[] | undefined {
    return this.dataModel?.getTrains();
  }

  deleteTrain(key: number) {
    this.dataModel?.deleteTrain(key);
  }

  editTrain(train: Train) {
    this.onEdit.emit(train);
    this.selectedTrain = train;
  }

  cancelEdit() {
    console.log("cancelando desde boton")
    this.onCancelEdit.emit();
    this.selectedTrain = null;
  }

  EditOrCancelClass(train: Train): string {
    if (this.selectedTrain != null) {
      return this.selectedTrain.id == train.id ? 'btn-secondary' : 'btn-warning'
    } else {
      return 'btn-warning';
    }
  }

  EditOrCancelText(train: Train): string {
    if (this.selectedTrain != null) {
      return this.selectedTrain.id == train.id ? 'Cancelar' : 'Editar'
    } else {
      return 'Editar';
    }
  }

}
