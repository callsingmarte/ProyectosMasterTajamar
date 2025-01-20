import { RouterModule, Routes } from '@angular/router';
import { FormComponent } from './core/form/form.component';
import { TableComponent } from './core/table/table.component';

export const routes: Routes = [
  //{ path: 'form/edit', component: FormComponent },
  //{ path: 'form/create', component: FormComponent },
  { path: 'form/edit/:id', component: FormComponent},
  { path: 'form/mode', component: FormComponent},
  { path: '', component: TableComponent}
];

export const routing = RouterModule.forRoot(routes);

//http://localhost:4200/form/edit
//http://localhost:4200/form/create
//http://localhost:4200/
