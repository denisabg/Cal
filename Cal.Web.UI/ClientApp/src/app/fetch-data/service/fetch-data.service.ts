import { HttpClient } from "@angular/common/http";
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { iStatusState } from "../interface/iStatusState";



@Injectable({
    providedIn: 'root'
})
export class DataService {

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string) {
    }

    public statusesList: Array<iStatusState> = [];

    getStatus(): Observable<Array<iStatusState>> {

        return this.http.get<iStatusState[]>(this.baseUrl + 'Fetcher').pipe(tap(result => {
            this.statusesList = ((result) as iStatusState[]);
        }, error => console.error(error)));
    }

    setState(item: iStatusState): Observable<iStatusState> {

        let id = item.id;
        let state = item.state;

        return this.http.put<iStatusState>(this.baseUrl + `Fetcher?id=${id}`, state).pipe(tap(result => {
            ((result) as iStatusState);
        }, error => console.error(error)));
    }



}
