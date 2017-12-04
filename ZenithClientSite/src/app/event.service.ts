import { Injectable } from '@angular/core';
import { Event } from './event'
import { Headers, Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

@Injectable()
export class EventService {

    private BASE_URL = "http://aspzenithsociety2.azurewebsites.net/api/eventsapi"; 

    constructor(private http: Http) { } 

    getEvents(): Promise<Event[]> {
        return this.http.get(this.BASE_URL)
            .toPromise()
            .then(response => response.json() as Event[])
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    }
}
