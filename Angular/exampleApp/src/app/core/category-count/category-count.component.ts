import { ChangeDetectorRef, Component, KeyValueDiffer, KeyValueDiffers } from '@angular/core';
import { Model } from '../../model/repository.model';

@Component({
  selector: 'app-category-count',
  imports: [],
  template: `<div class="bg-primary p-2 text-white">
                There are {{count}} categories
               </div>`,
  styleUrl: './category-count.component.css'
})
export class CategoryCountComponent {
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
      this.count = this.model.getProducts().map(p => p.category)
        .filter((category, index, array) => array.indexOf(category) == index).length;
    }
  }

}
