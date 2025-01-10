import { ContentChildren, Directive, Input, QueryList, SimpleChanges, contentChildren } from "@angular/core";
import { PaCellColor } from "./cellColor.directive";

@Directive({
  selector: "table"
})
export class PaCellColorSwitcher {
 
  @Input("PaCellDarkColor")
  modelProperty: boolean | undefined;
 
  @ContentChildren(PaCellColor, {descendants:true}) /*ContentChild para que coja el primer hijo y ContentChildren para todos los hijos*/
  contentChildren: QueryList<PaCellColor> | undefined;
 
  ngOnChanges(changes: SimpleChanges) {
    //if (this.contentChild != null) {
    //  this.contentChild.setColor(changes["modelProperty"].currentValue);
    //}
    this.updateContentChildren(changes["modelProperty"].currentValue);
  }

  ngAfterContentInit() {
    if (this.modelProperty != undefined) {
      this.contentChildren?.changes.subscribe(() => {
        this.updateContentChildren(this.modelProperty as boolean)
      })
    }
  }
 
  private updateContentChildren(dark: boolean) {
    if (this.contentChildren != null && dark != undefined) {
      this.contentChildren.forEach((child, index) => {
        child.setColor(index % 2 ? dark : !dark);
      });
    }
  }
}
