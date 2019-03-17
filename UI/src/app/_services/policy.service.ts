import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '@environments/environment';
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class PolicyService {
    private policyApiUrl: string = `${environment.apiUrl}/Policy`;

    constructor(private http: HttpClient) { }

    getPolicies() {
        return this.http.get<any>(`${this.policyApiUrl}/Get`)
            .pipe(
                map(result => { return JSON.parse(result); })
            );
    }

    getPolicyById(id: number) {
        return this.http.get<any>(`${this.policyApiUrl}/Get/${ id = id}`)
            .pipe(
                map(result => { return JSON.parse(result); })
            );
    }

    addPolicy(entity: any){
        return this.http.post<any>(`${this.policyApiUrl}/Create`, entity)
            .pipe(
                map(response => { return JSON.parse(response) })
            );
    }

    editPolicy(entity: any){
        return this.http.put<any>(`${this.policyApiUrl}/Update`, entity)
            .pipe(
                map(response => { return JSON.parse(response) })
            );
    }
    
    deletePolicy(id: number){
        return this.http.delete<any>(`${this.policyApiUrl}/Delete/${ id = id }`)
            .pipe(
                map(response => { return JSON.parse(response) })
            );
    }
}