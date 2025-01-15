import { Train } from "./train.model";

export class SimpleDataSource {
  private data: Train[];
  constructor() {
    this.data = new Array<Train>(
      new Train(1, 'intercity express', new Date('2025-01-15T08:30:00'), 'Madrid'),
      new Train(2, 'regional commuter', new Date('2025-01-15T10:45:00'), 'Barcelona'),
      new Train(3, 'high speed train', new Date('2025-01-14T18:15:00'), 'Sevilla'),
      new Train(4, 'night sleeper', new Date('2025-01-16T23:30:00'), 'Valencia'),
      new Train(5, 'freight carrier', new Date('2025-01-15T04:00:00'), 'Bilbao')
    );
  }
  getData(): Train[] {
    return this.data;
  }
}
