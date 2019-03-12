import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { User } from '@app/_models';
import { environment } from '@environments/environment'

import { Md5 } from 'ts-md5/dist/md5';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private authApiUrl: string = `${environment.apiUrl}/Auth`;
    private currentUserSubject: BehaviorSubject<User>;
    public currentUser: Observable<User>;

    constructor(private http: HttpClient) {
        this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): User {
        return this.currentUserSubject.value;
    }

    login(username: string, password: string) {
        const md5 = new Md5();
        password = md5.appendStr(password).end().toString();
        return this.http.post<any>(`${this.authApiUrl}/LogIn`, { username, password })
            .pipe(map(user => {
                if (user && user.Token) {
                    localStorage.setItem('currentUser', JSON.stringify(user));
                    this.currentUserSubject.next(user);
                }

                return user;
            }));
    }

    logout() {
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
    }
}