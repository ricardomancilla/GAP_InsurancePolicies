import { Component } from '@angular/core';

import { User } from '@app/_models';
import { AuthenticationService } from '@app/_services';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {
    user: User;

    constructor(private authenticationService: AuthenticationService) { }

    ngOnInit() {
        this.user = this.authenticationService.currentUserValue;
    }
}