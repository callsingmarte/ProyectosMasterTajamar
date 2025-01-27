import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {

    username?: string;
    password?: string;
    errorMessage?: string;

    constructor(private router: Router, private auth: AuthService) { }

    ngOnInit(): void {
    }

    authenticate(form: NgForm) {
        if (form.valid) {
            this.auth.authenticate(this.username ?? "", this.password ?? "")
                .subscribe(response => {
                    if (response) {
                        this.router.navigateByUrl("/admin/main");
                    }
                    this.errorMessage = "Auth Failed";
                })
            this.router.navigateByUrl("/admin/main");
        } else {
            this.errorMessage = "Form Data Invalid";
        }
    }

}
