import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IArticle } from '../article/article';
import { DiscountService } from '../services/discount.service';

@Component({
  selector: 'app-discount-editor',
  imports: [FormsModule, CommonModule],
  templateUrl: './discount-editor.component.html',
  styleUrl: './discount-editor.component.css'
})
export class DiscountEditorComponent {

  @Input() articles: IArticle[] = []; //maneja los articulos a los que aplico el discount
  @Input() selectedArticle: IArticle | null = null; //articulo seleccionado a descontar
  @Input() discountPercentage: number = 0; //Porcentaje a descontar

  @Output() discountSelected = new EventEmitter<number>(); //Emite el descuento seleccionado
  discountOptions: number[] = [5, 10, 15, 25, 50];

  constructor(public discounter: DiscountService) {}

  onDiscountChange() {
    this.discountSelected.emit(this.discountPercentage);
  }



}
