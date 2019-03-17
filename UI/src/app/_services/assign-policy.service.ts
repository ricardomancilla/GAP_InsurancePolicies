import { Injectable } from '@angular/core';
import { environment } from '@environments/environment';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class AssignPolicyService {
    private apiUrl: string = `${environment.apiUrl}/CustomerPolicy`;

    constructor(private http: HttpClient) { }

    getPoliciesAssignment() {
        return this.http.get<any>(`${this.apiUrl}/Get`)
            .pipe(
                map(result => { return JSON.parse(result); })
            );
    }

    assignPolicy(entity: any) {
        return this.http.post<any>(`${this.apiUrl}/Create`, entity)
            .pipe(
                map(response => { return JSON.parse(response) })
            );
    }

    unassignPolicy(id: number) {
        return this.http.delete<any>(`${this.apiUrl}/Delete/${id = id}`)
            .pipe(
                map(response => { return JSON.parse(response) })
            );
    }
}