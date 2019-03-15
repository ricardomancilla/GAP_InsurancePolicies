import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '@environments/environment';
import { Department } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class DepartmentService {
    private departmentApiUrl: string = `${environment.apiUrl}/Department`;
    
    constructor(private http: HttpClient) { }

    getDepartments(){
        return this.http.get<Department[]>(`${this.departmentApiUrl}/Get`);
    }
}