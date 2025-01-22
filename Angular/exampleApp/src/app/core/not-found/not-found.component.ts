import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-not-found',
  imports: [RouterModule],
  template: `<h3 class="bg-danger text-white p-2"> Sorry, something went wrong </h3>
             <button class="btn btn-primary" routerLink="/"> Start Over </button>
            `,
  styleUrl: './not-found.component.css'
})
export class NotFoundComponent {

}
