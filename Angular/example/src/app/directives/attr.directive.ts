import { Attribute, Directive, ElementRef, Input } from "@angular/core";

@Directive({
  selector: "[pa-attr]"
})

export class PaAttrDirective {
  constructor(private element: ElementRef) {
  }
  @Input("pa-attr")
  bgClass: string | null = "";
  ngOnInit() {
    this.element.nativeElement.classList.add(this.bgClass || "table-success", "fw-bold");
  }
//  constructor(element: ElementRef, @Attribute("pa-attr") bgClass:string) {
//    element.nativeElement.classList.add(bgClass || "table-success", "fw-bold");
//  }
}
