import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatchEvent, MatchPreview } from '../../model/match';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatchService } from '../../services/match-service.service';
import { AuthGuardService } from 'src/app/services/auth-guard.service';

@Component({
  selector: 'app-match-events',
  templateUrl: './match-events.component.html',
  styleUrls: ['./match-events.component.css']
})
export class MatchEventsComponent {
  @Input() matchId: string = ''
  @Output() updateEvent = new EventEmitter<MatchEvent>()

  events : MatchEvent[] = []

  updateMatch(value: any) {
    this.updateEvent.emit(value);
  }

  form : FormGroup
  isAdmin : boolean

  constructor(private fb: FormBuilder,public matchService:MatchService,private auth:AuthGuardService) {
    this.isAdmin = this.auth.isAdmin()
    this.form = this.fb.group({
      minute: ['',[Validators.required,Validators.maxLength(6)]],
      text: ['',[Validators.required,Validators.minLength(5),Validators.maxLength(100)]],
    })
  }

  ngOnInit(){
    this.matchService.getMatchEvents(this.matchId).subscribe(
      response =>{
        if(response)
          this.events = response
      }
    )
  }

  onSubmit() {
    if (this.form.valid) {
      const event : MatchEvent = {
        minute : this.form.value.minute,
        text : this.form.value.text
      }
      this.events.push(event)
    }
  }

  removeEvent(event:MatchEvent){
    this.events.forEach((element,index) => {
      if(element==event){
        this.events.splice(index,1)
      }
    });
  }

  saveChanges(){
    this.matchService.updateMatchEvents(this.matchId,this.events).subscribe(
      response => this.updateMatch(response)
    )
  }
}
