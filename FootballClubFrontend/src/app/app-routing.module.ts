import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateMatchComponent } from './create-match/create-match.component';
import { MatchesComponent } from './match-folder/matches/matches.component';
import { CreatePlayerComponent } from './create-player/create-player.component';
import { MatchDetailsComponent } from './match-folder/match-details/match-details.component';
import { RegisterComponent } from './user-folder/register/register.component';

const routes: Routes = [
  {path:'matches/create',component:CreateMatchComponent},
  {path:'matches',component:MatchesComponent},
  {path:'players/create',component:CreatePlayerComponent},
  {path:'match/:date/:opponent',component:MatchDetailsComponent},
  {path:'register',component:RegisterComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
