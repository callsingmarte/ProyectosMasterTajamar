import { ChangeDetectorRef, Component, KeyValueDiffer, KeyValueDiffers } from '@angular/core';
import { Model } from '../../model/repository.model';

@Component({
  selector: 'app-product-count',
  imports: [],
  template: `<div class="bg-info text-white p-2">
             There are {{count}} products
            </div>`,
  styleUrl: './product-count.component.css'
})
export class ProductCountComponent {
  private differ?: KeyValueDiffer<any, any>;
  count: number = 0;

  constructor(private model: Model,
    private KeyValueDiffers: KeyValueDiffers,
    private changeDetector: ChangeDetectorRef) { }

  ngOnInit() {
    this.differ = this.KeyValueDiffers.find(this.model.getProducts()).create()
  }

  ngDoCheck() {
    if (this.differ?.diff(this.model.getProducts()) != null) {
      this.updateContent();
    }
  }

  private updateContent() {
    this.count = this.model.getProducts().length;
  }

}

//ChangeDetectorRef keyValueDiffer, keyValueDiffers
