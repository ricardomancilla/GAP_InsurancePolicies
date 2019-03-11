import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '@environments/environment';
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class DepartmentService {
    constructor(private http: HttpClient) { }

    getDepartments(){
        return this.http.get<any>(`${environment.apiUrl}/Department/Get`)
            .pipe(map(departments => {
                return departments;
            }));
    }
}