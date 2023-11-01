import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateMatchComponent } from './create-match/create-match.component';
import { MatchesComponent } from './matches/matches.component';
import { CreatePlayerComponent } from './create-player/create-player.component';
import { MatchDetailsComponent } from './match-details/match-details.component';

const routes: Routes = [
  {path:'matches/create',component:CreateMatchComponent},
  {path:'matches',component:MatchesComponent},
  {path:'players/create',component:CreatePlayerComponent},
  {path:'match/:date/:opponent',component:MatchDetailsComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
