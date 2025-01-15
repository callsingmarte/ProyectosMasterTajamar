import { Directive, ElementRef, HostListener, Input } from "@angular/core";

@Directive({
  selector: "[appHighlight]"
})

export class HighlightDirective {
  constructor(private el: ElementRef) { }

  @Input("appHighlight")
  departure : Date | undefined

  @HostListener('mouseenter') onMouseEnter() {
    const departure = this.departure || undefined;
    const now = new Date();
    if (departure == undefined) {
      this.highlight(null);
    } else {
      const timeDiff = departure.getTime() - now.getTime();

      if (timeDiff > 0 && timeDiff < 3600000) { // menos de 1 hora
        this.highlight('table-success');
      }
    }
  }

  @HostListener('mouseleave') onMouseLeave() {
    this.el.nativeElement.classList.remove("table-success");
  }

  private highlight(clase: string | null) {
    this.el.nativeElement.classList.add(clase);
  }
}
