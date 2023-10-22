import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateMatchComponent } from './create-match/create-match.component';
import { MatchesComponent } from './matches/matches.component';

const routes: Routes = [
  {path:'create',component:CreateMatchComponent},
  {path:'matches',component:MatchesComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
