import { Component, OnInit } from '@angular/core';
import { MatchService } from '../../services/match-service.service';
import { MatchPreview } from '../../model/match';
import { Router } from '@angular/router';
import { AuthGuardService } from 'src/app/services/auth-guard.service';

@Component({
  selector: 'app-matches',
  templateUrl: './matches.component.html',
  styleUrls: ['./matches.component.css'],
})
export class MatchesComponent {
  
  matches : MatchPreview[] = [];
  selectedTab : string = 'Fixtures';
  competition : string = 'any';
  year : number = this.getCurrentSeason()
  isAdmin : boolean

  constructor(private matchService: MatchService,private router:Router,private auth: AuthGuardService) {
    this.isAdmin = this.auth.isAdmin()
  }

  ngOnInit() {
    this.matchService.getFixtures(this.competition).subscribe((response) => {
      this.matches = response;
    });
  }

  selectTab(tab: string) {
    this.selectedTab = tab;
    if(this.selectedTab=='Results'){
      this.matchService.getResults(this.competition,this.year).subscribe((response) => {
        this.matches = response;
      });
    }
    if(this.selectedTab=='Fixtures'){
      this.matchService.getFixtures(this.competition).subscribe((response) => {
        this.matches = response;
      });
    }
  }

  competitionSelected(event:any){
    this.competition = event.target.value
    if(this.selectedTab=='Results'){
      this.matchService.getResults(this.competition,this.year).subscribe((response) => {
        this.matches = response;
      });
    }
    if(this.selectedTab=='Fixtures'){
      this.matchService.getFixtures(this.competition).subscribe((response) => {
        this.matches = response;
      });
    }
  }

  seasonSelected(event:any){
    this.year = parseInt(event.target.value.split("/")[0])
    if(this.selectedTab=='Results'){
      this.matchService.getResults(this.competition,this.year).subscribe((response) => {
        this.matches = response;
      });
    }
    if(this.selectedTab=='Fixtures'){
      this.matchService.getFixtures(this.competition).subscribe((response) => {
        this.matches = response;
      });
    }
  }

  newMatch(){
    this.router.navigateByUrl('matches/create')
  }
  
  getCurrentSeason(){
    let d = new Date()
    if(d.getMonth()>5)
      return d.getFullYear()
    return d.getFullYear()-1
  }
}
