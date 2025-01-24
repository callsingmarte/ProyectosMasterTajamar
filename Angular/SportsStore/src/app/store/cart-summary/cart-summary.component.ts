import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Cart } from '../../model/cart.model';

@Component({
  selector: 'app-cart-summary',
  imports: [CommonModule],
  templateUrl: './cart-summary.component.html',
  styleUrl: './cart-summary.component.css'
})
export class CartSummaryComponent {
  constructor(public cart: Cart) { }
}
