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
    weekOffset: number;

    constructor(private eventService: EventService) {
        this.weekOffset = 0;
     }

    getEvents(): void {
        this.eventService.getEvents().then(events => {
            this.events = events;
            for (let i = 0; i < events.length; i++) {
                //console.log(events[i].dateFrom);
                events[i].dateFrom = new Date(events[i].dateFrom);
                events[i].dateTo = new Date(events[i].dateTo);
                events[i].creationDate = new Date(events[i].creationDate);
            }
        
        });
    }

    ngOnInit(): void {
        this.getEvents();
    }

    filter(allEvents: Event[]): Event[] {
        let result: Event[] = [];

        var date = new Date(new Date().getTime() + this.weekOffset * 7 * 24 * 60 * 60 * 1000);
        var day = date.getDay();
        var diff = date.getDate() - day + (day == 0 ? -6 : 1);
        var thisMonday = new Date(date.setDate(diff));
        var nextMonday = new Date(thisMonday.getTime() + 7 * 24 * 60 * 60 * 1000);

        for (let i = 0; i < allEvents.length; ++i) {
            if(allEvents[i].dateFrom > thisMonday && allEvents[i].dateFrom < nextMonday) {
                result.push(allEvents[i]);
            }
        }

        return result;
    }

    onPrev(): void {
        --this.weekOffset;
    }

    onNext(): void {
        ++this.weekOffset;
    }
}
