import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Event } from './event';
import { EventService } from './event.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    providers: [EventService]
})
export class AppComponent implements OnInit {
    
    events: Event[];

    constructor(private eventService: EventService) { }

    getEvents(): void {
        this.eventService.getEvents().then(events => this.events = events);
    }

    ngOnInit(): void {
        this.getEvents();
    }
}
