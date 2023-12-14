import { Component, OnInit } from '@angular/core';
import { MatchService } from '../../services/match-service.service';
import { MatchPreview } from '../../model/match';

@Component({
  selector: 'app-matches',
  templateUrl: './matches.component.html',
  styleUrls: ['./matches.component.css'],
})
export class MatchesComponent {
  constructor(private matchService: MatchService) {}

  matches : MatchPreview[] = [];
  selectedTab: string = 'Fixtures';

  ngOnInit() {
    this.matchService.getFixtures().subscribe((response) => {
      this.matches = response;
    });
  }

  selectTab(tab: string) {
    this.selectedTab = tab;
    if(this.selectedTab=='Results'){
      this.matchService.getResults().subscribe((response) => {
        this.matches = response;
      });
    }
    if(this.selectedTab=='Fixtures'){
      this.matchService.getFixtures().subscribe((response) => {
        this.matches = response;
      });
    }
  }
}
