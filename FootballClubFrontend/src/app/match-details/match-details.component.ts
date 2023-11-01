import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatchService } from '../services/match-service.service';

@Component({
  selector: 'app-match-details',
  templateUrl: './match-details.component.html',
  styleUrls: ['./match-details.component.css'],
})
export class MatchDetailsComponent {
  match: any;
  selectedTab: string = 'News';

  constructor(
    private route: ActivatedRoute,
    public matchService: MatchService
  ) {}

  ngOnInit(): void {
    this.matchService
      .getByDate(this.getDateFromPath())
      .subscribe((response) => (this.match = response));
  }

  getDateFromPath(): string {
    let components = this.route.snapshot.paramMap.get('date')?.split('-');
    if (components)
      return components[2] + '-' + components[1] + '-' + components[0];
    return '';
  }

  selectTab(tab: string) {
    this.selectedTab = tab;
  }

  updateMatch(match: any) {
    this.match = match
  }
}
