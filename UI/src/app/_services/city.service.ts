import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '@environments/environment';
import { City } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class CityService {
    private cityApiUrl: string = `${environment.apiUrl}/City`;
    constructor(private http: HttpClient) { }

    getCities(){
        return this.http.get<City[]>(`${this.cityApiUrl}/Get`);
    }
}