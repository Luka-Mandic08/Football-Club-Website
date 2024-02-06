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
import { ArticleComponent } from './article-folder/article/article.component';
import { HomeComponent } from './home/home.component';
import { AuthGuardService } from './services/auth-guard.service';
import { ArticlesComponent } from './article-folder/articles/articles.component';

const routes: Routes = [
  {path:'matches/create',component:CreateMatchComponent, canActivate: [AuthGuardService], data: { roles: 'Admin' }},
  {path:'matches',component:MatchesComponent},
  {path:'players/create',component:CreatePlayerComponent, canActivate: [AuthGuardService], data: { roles: 'Admin' }},
  {path:'match/:date/:opponent',component:MatchDetailsComponent},
  {path:'register',component:RegisterComponent},
  {path:'team',component:AllPlayersComponent},
  {path:'players/:name',component:PlayerComponent},
  {path:'articles/create',component:CreateArticleComponent, canActivate: [AuthGuardService], data: { roles: 'Admin' }},
  {path:'tables/edit',component:TablesEditComponent, canActivate: [AuthGuardService], data: { roles: 'Admin' }},
  {path:'article/:title',component:ArticleComponent},
  {path:'articles/:type',component:ArticlesComponent},
  {path:'',component:HomeComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
