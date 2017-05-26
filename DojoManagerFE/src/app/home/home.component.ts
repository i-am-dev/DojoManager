import { Component, OnInit } from '@angular/core';

import { User } from '../_models/index';
import { UserService } from '../_services/index';
import { AuthenticationService } from '../_services/authentication.service';

@Component({
    moduleId: module.id,
    templateUrl: 'home.component.html'
})

export class HomeComponent implements OnInit {
    users: User[] = [];

    constructor(private userService: UserService, private authService: AuthenticationService) { 

    }

    ngOnInit() {
        // get users from secure api end point
       /* this.userService.getUsers()
            .subscribe(users => {
                this.users = users;
            });*/
            if(this.authService.checkIfJWTExpired(this.authService.user)){
                console.log('Token Still Valid');
            }else{
                console.log('Token expired');
            }
    }

}
