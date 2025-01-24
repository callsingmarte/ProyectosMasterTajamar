import { Routes } from '@angular/router';
import { StoreComponent } from './store/store.component';
import { CartDetailComponent } from './store/cart-detail/cart-detail.component';
import { CheckOutComponent } from './store/check-out/check-out.component';

export const routes: Routes = [
  {path: 'store', component: StoreComponent },
  { path: 'cart', component: CartDetailComponent },
  { path: 'checkout', component: CheckOutComponent },
  { path: "**", redirectTo:"/store" }
];
