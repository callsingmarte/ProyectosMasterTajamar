import { SimpleDataSource } from "./datasource.model";
import { Train } from "./train.model";

export class Model {
  private dataSource: SimpleDataSource;
  private trains: Train[];
  private locator = (t: Train, id: number) => t.id == id;
  constructor() {
    this.dataSource = new SimpleDataSource();
    this.trains = new Array<Train>();
    this.dataSource.getData().forEach(t => this.trains.push(t));
  }

  getTrains(): Train[] {
    return this.trains;
  }

  getTrain(id: number): any {
    return this.trains.find(t => this.locator(t, id));
  }

  private generateId(): number {
    let candidate = this.trains.length;
    while (this.getTrain(candidate) != null) {
      candidate++;
    }
    return candidate;
  }

  saveTrain(train: any) {
    if (train.id == 0 || train.id == null) {
      //Añade un tren sino tiene id
      train.id = this.generateId();
      train.departure = new Date(train.departure);
      this.trains.push(train);
    } else {
      //Actualiza un tren si tiene id
      let index = this.trains.findIndex(t => this.locator(t, train.id));
      train.departure = new Date(train.departure);
      this.trains.splice(index, 1, train);
    }
  }

  deleteTrain(id: number) {
    let index = this.trains.findIndex(t => this.locator(t, id));
    if (index > -1) {
      this.trains.splice(index, 1);
    }
  }
}
