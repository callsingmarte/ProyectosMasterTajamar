import { Attribute, Directive, ElementRef, HostBinding, Input } from "@angular/core";

@Directive({
  selector: "[cu-attr]"
})

export class CuAttrDirective {

  constructor(private element: ElementRef) {}

  @Input("cu-attr")
  bgClass: string | null = "";

  ngOnInit() {
    this.element.nativeElement.classList.add(this.bgClass || "bg-info", "text-white");

  }

}
