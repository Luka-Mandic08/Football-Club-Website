import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CreateMatchComponent } from './create-match/create-match.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatchCardComponent } from './match-card/match-card.component';
import { MatchesComponent } from './matches/matches.component';
import { CreatePlayerComponent } from './create-player/create-player.component';
import { MatchDetailsComponent } from './match-details/match-details.component';
import { EditMatchDetailsComponent } from './edit-match-details/edit-match-details.component';
import { MatchEventCardComponent } from './match-event-card/match-event-card.component';
import { MatchEventsComponent } from './match-events/match-events.component';

@NgModule({
  declarations: [
    AppComponent,
    CreateMatchComponent,
    MatchCardComponent,
    MatchesComponent,
    CreatePlayerComponent,
    MatchDetailsComponent,
    EditMatchDetailsComponent,
    MatchEventCardComponent,
    MatchEventsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
