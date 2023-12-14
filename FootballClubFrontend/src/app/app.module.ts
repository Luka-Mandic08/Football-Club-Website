import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MatDialogModule } from '@angular/material/dialog';
import { CreateMatchComponent } from './create-match/create-match.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatchCardComponent } from './match-folder/match-card/match-card.component';
import { MatchesComponent } from './match-folder/matches/matches.component';
import { CreatePlayerComponent } from './create-player/create-player.component';
import { MatchDetailsComponent } from './match-folder/match-details/match-details.component';
import { MatchEventCardComponent } from './match-folder/match-event-card/match-event-card.component';
import { MatchEventsComponent } from './match-folder/match-events/match-events.component';
import { MatchSquadsComponent } from './match-folder/match-squads/match-squads.component';
import { MatchStatisticsEditComponent } from './match-folder/match-statistics-edit/match-statistics-edit.component';
import { LoginComponent } from './user-folder/login/login.component';
import { RegisterComponent } from './user-folder/register/register.component';
import { NavbarComponent } from './navbar/navbar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DragDrop, DragDropModule } from '@angular/cdk/drag-drop';
import { MatchPlayerStatisticsEditComponent } from './match-folder/match-player-statistics-edit/match-player-statistics-edit.component';
import { MatchStatisticsComponent } from './match-folder/match-statistics/match-statistics.component';
import { MatchPlayerStatisticsComponent } from './match-folder/match-player-statistics/match-player-statistics.component';
import { AllPlayersComponent } from './player-folder/all-players/all-players.component';
import { PlayerComponent } from './player-folder/player/player.component';

@NgModule({
  declarations: [
    AppComponent,
    CreateMatchComponent,
    MatchCardComponent,
    MatchesComponent,
    CreatePlayerComponent,
    MatchDetailsComponent,
    MatchEventCardComponent,
    MatchEventsComponent,
    MatchSquadsComponent,
    MatchStatisticsEditComponent,
    LoginComponent,
    RegisterComponent,
    NavbarComponent,
    MatchPlayerStatisticsEditComponent,
    MatchStatisticsComponent,
    MatchPlayerStatisticsComponent,
    AllPlayersComponent,
    PlayerComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatDialogModule,
    DragDropModule,    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
