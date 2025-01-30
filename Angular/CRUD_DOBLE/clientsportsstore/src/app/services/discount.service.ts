import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})

export class DiscountService {
  constructor() { }

  private discountValue: number = 5;

  public get discount(): number {
    return this.discountValue;
  }

  public set discount(newValue: number) {
    this.discountValue = newValue || 0;
  }

  public applyDiscount(price: number) {
    return Math.max(price - this.discountValue, 5);
  }

}
