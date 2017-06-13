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
    }

}
