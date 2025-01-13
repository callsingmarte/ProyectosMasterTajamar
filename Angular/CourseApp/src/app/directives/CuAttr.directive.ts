import { Directive, HostBinding } from "@angular/core";

@Directive({
  selector: "[cu-attr]"
})

export class CuAttrDirective {
  @HostBinding("class")
  classList : string = "bg-info text-white"
}
