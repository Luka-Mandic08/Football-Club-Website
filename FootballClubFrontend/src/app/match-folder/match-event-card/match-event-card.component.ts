import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatchEvent } from '../../model/match';
import { AuthGuardService } from 'src/app/services/auth-guard.service';

@Component({
  selector: 'app-match-event-card',
  templateUrl: './match-event-card.component.html',
  styleUrls: ['./match-event-card.component.css']
})
export class MatchEventCardComponent {

  @Input() event!:MatchEvent
  @Output() removeEvent = new EventEmitter<MatchEvent>()

  isAdmin : boolean

  constructor(private auth:AuthGuardService){
    this.isAdmin = this.auth.isAdmin()
  }

  deleteEvent(value: MatchEvent) {
    this.removeEvent.emit(value);
  }
}
