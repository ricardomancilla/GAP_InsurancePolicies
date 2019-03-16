import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '@environments/environment';
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class CodeService {
    private codeApiUrl: string = `${environment.apiUrl}/Code`;
    constructor(private http: HttpClient) { }

    getCodes(filter: string){
        return this.http.get<any>(`${this.codeApiUrl}/Get/?filter=${ filter }`)
            .pipe(
                map(result => { return JSON.parse(result); })
            );
    }
}