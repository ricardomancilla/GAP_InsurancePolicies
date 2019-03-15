import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { Md5 } from 'ts-md5/dist/md5';

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

    get loginForm() { return this.loginFormGroup.controls; }

    onSubmit() {
        this.submitted = true;

        if (this.loginFormGroup.invalid) { return; }

        this.loading = true;
        
        const md5 = new Md5();
        var password = md5.appendStr(this.loginForm.password.value).end().toString();

        this.authenticationService.login(this.loginForm.username.value, password)
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
