import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '@environments/environment';
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class CustomerService {
    constructor(private http: HttpClient) { }

    getCustomersByFilter(){
        return this.http.get<any>(`${environment.apiUrl}/Customer/GetBy`, {  })
            .pipe(map(customers => {
                return customers;
            }));
    }
}