import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateMatchComponent } from './match-folder/create-match/create-match.component';
import { MatchesComponent } from './match-folder/matches/matches.component';
import { CreatePlayerComponent } from './player-folder/create-player/create-player.component';
import { MatchDetailsComponent } from './match-folder/match-details/match-details.component';
import { RegisterComponent } from './user-folder/register/register.component';
import { AllPlayersComponent } from './player-folder/all-players/all-players.component';
import { PlayerComponent } from './player-folder/player/player.component';
import { CreateArticleComponent } from './article-folder/create-article/create-article.component';
import { TablesEditComponent } from './table-folder/tables-edit/tables-edit.component';

const routes: Routes = [
  {path:'matches/create',component:CreateMatchComponent},
  {path:'matches',component:MatchesComponent},
  {path:'players/create',component:CreatePlayerComponent},
  {path:'match/:date/:opponent',component:MatchDetailsComponent},
  {path:'register',component:RegisterComponent},
  {path:'team',component:AllPlayersComponent},
  {path:'players/:name',component:PlayerComponent},
  {path:'articles/create',component:CreateArticleComponent},
  {path:'tables/edit',component:TablesEditComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
