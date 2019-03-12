import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '@environments/environment';
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class CityService {
    private cityApiUrl: string = `${environment.apiUrl}/City`;
    constructor(private http: HttpClient) { }

    getCities(){
        return this.http.get<any>(`${this.cityApiUrl}/Get`)
            .pipe(map(cities => {
                return cities;
            }));
    }
}