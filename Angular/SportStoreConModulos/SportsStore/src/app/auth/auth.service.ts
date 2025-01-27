import { Injectable } from '@angular/core';
import { RestDataSource } from '../model/rest.datasource';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

    constructor(private datasource: RestDataSource) { }

    authenticate(username: string, password: string): Observable<boolean> {
        return this.datasource.authenticate(username, password);
    }

    get authenticated(): boolean {
        return this.datasource.auth_token != null
    }

    clear() {
        this.datasource.auth_token = undefined;
    }

}
