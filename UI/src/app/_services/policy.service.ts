import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '@environments/environment';
import { map } from 'rxjs/operators';
import { Policy } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class PolicyService {
    private policyApiUrl: string = `${environment.apiUrl}/Policy`;
    
    constructor(private http: HttpClient) { }

    getPolicies(){
        return this.http.get<Policy[]>(`${this.policyApiUrl}/Get`);
    }

    getPolicyById(id: number){
        return this.http.get<Policy>(`${this.policyApiUrl}/Get/${id}`);
    }
}