import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

    constructor(private auth: AuthService, private router: Router) { }

  ngOnInit(): void {
  }

    logout() {
        this.auth.clear();
        this.router.navigateByUrl("/");
    }
}
