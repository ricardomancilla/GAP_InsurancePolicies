import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '@environments/environment';
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class DepartmentService {
    private departmentApiUrl: string = `${environment.apiUrl}/Department`;
    
    constructor(private http: HttpClient) { }

    getDepartments(){
        return this.http.get<any>(`${this.departmentApiUrl}/Get`)
            .pipe(
                map(result => { return JSON.parse(result); })
            );
    }
}