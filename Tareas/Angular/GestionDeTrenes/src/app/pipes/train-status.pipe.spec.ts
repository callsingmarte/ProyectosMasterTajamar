import { TrainStatusPipe } from './train-status.pipe';

describe('TrainStatusPipe', () => {
  it('create an instance', () => {
    const pipe = new TrainStatusPipe();
    expect(pipe).toBeTruthy();
  });
});
