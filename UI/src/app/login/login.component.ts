import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AuthenticationService } from '@app/_services';

@Component({ 
    templateUrl: 'login.component.html'
})
export class LoginComponent implements OnInit {
    loginFormGroup: FormGroup;
    loading = false;
    submitted = false;
    returnUrl: string;
    error = '';

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService
    ) { }

    ngOnInit() {
        this.loginFormGroup = this.formBuilder.group({
            username: ['', Validators.required],
            password: ['', Validators.required]
        });

        this.authenticationService.logout();

        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }

    // convenience getter for easy access to form fields
    get loginForm() { return this.loginFormGroup.controls; }

    onSubmit() {
        this.submitted = true;

        // stop here if form is invalid
        if (this.loginFormGroup.invalid) {
            return;
        }

        this.loading = true;
        this.authenticationService.login(this.loginForm.username.value, this.loginForm.password.value)
            .pipe(first())
            .subscribe(
                () => {
                    this.router.navigate([this.returnUrl]);
                },
                error => {
                    this.error = error;
                    this.loading = false;
                });
    }
}
