﻿import { Login } from "@/_models";
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '@/_commons';


@Component({ templateUrl: 'login.component.html', styleUrls: ['../auth.component.scss'] })
export class LoginComponent implements OnInit {
    loginForm: FormGroup;
    loading = false;
    submitted = false;
    returnUrl: string;
    hidePassword = true;
    error = '';

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService
    ) {
        // redirect to home if already logged in
        if (this.authenticationService.currentUserValue) {
            this.router.navigate(['/']);
        }
    }

    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            username: ['', Validators.required],
            password: ['', Validators.required],
            rememberme: [false]
        });

        // get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';

        // loged in with external provider return token
        if (this.route.snapshot.queryParamMap.has('access_token')) {
            this.authenticationService.externalLogin(this.route.snapshot.queryParamMap.get('access_token'))
                .subscribe(resp => {
                    if (resp) {
                        this.router.navigate([this.returnUrl]);
                    }
                });
        }
    }

    // convenience getter for easy access to form fields
    get f() { return this.loginForm.controls; }

    onSubmit() {
        this.submitted = true;

        // stop here if form is invalid
        if (this.loginForm.invalid) {
            return;
        }

        let loginObj: Login = { username: this.f.username.value, password: this.f.password.value, rememberMe: this.f.rememberme.value }

        this.loading = true;
        this.authenticationService.login(loginObj)
            .pipe(first())
            .subscribe(
                data => {

                    if (data.hasToken)
                        this.router.navigate([this.returnUrl]);
                    else
                        this.error = data.messageResponse;

                    this.loading = false;
                },
                error => {
                    console.error(error);
                    this.loading = false;
                });
    }

    googleLogin() {
        this.authenticationService.googleRedirect();
    }

    facebookLogin() {
        this.authenticationService.facebookRedirect();
    }
}
