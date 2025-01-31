import { Directive, ElementRef, EventEmitter, HostListener, Input, Output, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appStockRow]'
})
export class StockRowDirective {

  @Input("appStockRow") stock!:number //Recibimos el valor del stock
  private buttonElement!: HTMLElement; // Referencia el boton de solicitud de productos a añadir al stock

  @Output() stockEdit = new EventEmitter<any>(); //emite el evento de los datos del articulo

  private buttonClickListener?: () => void; //Referencia al listener para limpiarlo al deshabilitar
  constructor(private el: ElementRef, private renderer: Renderer2) { }

  @HostListener('mouseenter') onMouseEnter() {
    if (this.stock < 10) {
      //activar el boton y darle un class
      const updateStockButton = this.el.nativeElement.querySelector('.btn-outline-primary');
      if (updateStockButton) {
        this.renderer.removeAttribute(updateStockButton, 'disabled')
      }
      //Añadir evento click al boton
      this.buttonClickListener = this.renderer.listen(updateStockButton, 'click', () => {
        const article = JSON.parse(this.el.nativeElement.dataset.article); //Obtiene el articulo asociado a cada linea
        console.log('Articulo emitido: ', article);
        this.stockEdit.emit(article); //Emite el articulo al hacer click
      });
      //Resaltar la fila
      const cells = this.el.nativeElement.querySelectorAll('td');
      cells.forEach((cell: HTMLElement) => {
        this.renderer.setStyle(cell, 'background-color', '#fff9d9');
      });
    }
  }

  @HostListener('mouseleave') onMouseLeave() {
    if (this.stock < 10) {
      //Quitar el resaltado de la fila
      const cells = this.el.nativeElement.querySelectorAll('td');
      cells.forEach((cell: HTMLElement) => {
        this.renderer.removeStyle(cell, 'background-color');
      });
      const updateStockButton = this.el.nativeElement.querySelector('.btn-outline-primary');
      if (updateStockButton) {
        this.renderer.setAttribute(updateStockButton, 'disabled', 'true');
      }
      //Eliminar el listener del boton
      if (this.buttonClickListener) {
        this.buttonClickListener(); //limpiamos el evento asociado al boton
        this.buttonClickListener = undefined;
      }
    }
  }

}
