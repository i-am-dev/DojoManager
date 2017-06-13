import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { AuthenticationService } from '../_services/index';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private router: Router, private auth: AuthenticationService) { }

    canActivate() {
        if (localStorage.getItem('profile')) {
            // logged in so check if the token is still valid
            if(this.auth.isTokenExpired()){
                // token is expired so lets try to refresh it
                console.log('Token expired');
                this.auth.refreshToken()
                    .subscribe(
                        data => {
                            console.log('Token Refreshed');
                            return true;
                        },
                        error => {
                            console.log('Token not refreshed');
                            // need to reauthenticate so redirect to login page
                            this.router.navigate(['/login']);
                            return false;
                    });
            } else {
                console.log('Token valid');
            }



            return true;
            
        }

        // not logged in so redirect to login page
        this.router.navigate(['/login']);
        return false;
    }
}
