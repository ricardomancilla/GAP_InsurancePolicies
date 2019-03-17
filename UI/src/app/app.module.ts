import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';
import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';

import { routing } from './app.routing';
import { JwtInterceptor, ErrorInterceptor, ConfirmationDialogComponent } from './_helpers';
import { AppComponent } from './app.component';
import { HomeComponent } from './home';
import { LoginComponent } from './login';
import { PolicyComponent, PolicyAddComponent, AssignPolicyComponent } from './policy';
import { DatePipe } from '@angular/common';

@NgModule({
    imports: [
        BrowserModule,
        NgbModule,
        ReactiveFormsModule,
        HttpClientModule,
        routing,
        BrowserAnimationsModule,
        OwlDateTimeModule,
        OwlNativeDateTimeModule,
        ToastrModule.forRoot({
            closeButton: true,
            timeOut: 7000,
            preventDuplicates: false,
            positionClass: 'toast-top-right'
        })
    ],
    declarations: [
        ConfirmationDialogComponent,
        AppComponent,
        HomeComponent,
        LoginComponent,
        PolicyComponent,
        PolicyAddComponent,
        AssignPolicyComponent
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
        DatePipe
    ],
    entryComponents: [PolicyAddComponent, ConfirmationDialogComponent, AssignPolicyComponent],
    bootstrap: [AppComponent]
})

export class AppModule { }