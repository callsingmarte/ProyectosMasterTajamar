import { ApplicationRef, Component } from "@angular/core";
import { Model } from "./repository.model";
import { CommonModule } from '@angular/common';
import { Product } from "./product.model";
import { FormsModule, NgForm, NgModel, ValidationErrors } from "@angular/forms";
import { ProductFormComponent } from "./product-form/product-form.component";
import { ProductTableComponent } from "./product-table/product-table.component";
import { AddTaxPipe } from "../../pipes/add-tax.pipe";
import { PaAttrDirective } from "../../directives/attr.directive";
import { PaIteratorDirective } from "../../directives/iterator.directive";
import { PaStructureDirective } from "../../directives/structure.directive";
import { PaModel } from "../../directives/twoway.directive";
import { PaCellColor } from "../../directives/cellColor.directive";
import { PaCellColorSwitcher } from "../../directives/cellColorSwitcher.directive";
import { ToggleViewComponent } from "../../components/toggle-view/toggle-view.component";
import { SimpleDataSource } from "./datasource.model";
import { DiscountService } from "../../services/discount.service";
@Component({
  selector: "app-product",
  imports: [CommonModule, FormsModule, PaAttrDirective,
    PaModel, PaStructureDirective, PaIteratorDirective,
    PaCellColor, PaCellColorSwitcher, ProductFormComponent,
    ProductTableComponent, ToggleViewComponent, AddTaxPipe], // Importa CommonModule aquí
  providers: [SimpleDataSource, Model, DiscountService],
  standalone: true, //Para corregir el error de cuando se usa el ngModel
  templateUrl: "./product.component.html"
})
export class ProductComponent {
  //model: Model = new Model();
  //showTable: boolean = false;
  //darkColor: boolean = false;



  //getProductByPosition(position: number): Product {
  //  return this.model.getProducts()[position];
  //}
  //getProduct(key: number): Product | undefined {
  //  return this.model.getProduct(key);
  //}

  //getProducts(): Product[] {
  //  return this.model.getProducts();
  //}
  
  //addProduct(p: Product) {
  //  this.model.saveProduct(p);
  //}

  //deleteProduct(key: number)
  //{
  //  this.model.deleteProduct(key);
  //}
}
