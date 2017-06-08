import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import { User } from '../_models/index';
import { UserService } from '../_services/index';
import { AuthenticationService } from '../_services/authentication.service';

@Component({
    moduleId: module.id,
    templateUrl: 'home.component.html'
})

export class HomeComponent implements OnInit {
    users: User[] = [];

    constructor(private userService: UserService, private authService: AuthenticationService, private router: Router) { 

    }

    ngOnInit() {
        // get users from secure api end point
       /* this.userService.getUsers()
            .subscribe(users => {
                this.users = users;
            });*/
            if(this.authService.checkIfJWTExpired(this.authService.user)){
                console.log('Token Still Valid');
                console.log(this.authService.user);
            }else{
                console.log('Token expired');
                this.authService.refreshJWT()
                    .subscribe(
                        data => {
                        },
                        error => {
                            //this.authService.logout();
                            this.router.navigate(['login']);
                        });
            }
    }

}
