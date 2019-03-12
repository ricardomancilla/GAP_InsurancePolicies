import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '@environments/environment';
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class CustomerService {
    private customerApiUrl: string = `${environment.apiUrl}/Customer`;
    
    constructor(private http: HttpClient) { }

    getCustomersByFilter(filter: string){
        return this.http.get<any>(`${this.customerApiUrl}/GetBy/${filter}`)
            .pipe(map(customers => {
                return customers;
            }));
    }
}