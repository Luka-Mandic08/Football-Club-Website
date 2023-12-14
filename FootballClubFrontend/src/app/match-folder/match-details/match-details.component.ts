import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatchService } from '../../services/match-service.service';
import { MatchPreview } from 'src/app/model/match';
import { PlayerStatistics } from 'src/app/model/player-statistics';

@Component({
  selector: 'app-match-details',
  templateUrl: './match-details.component.html',
  styleUrls: ['./match-details.component.css'],
})
export class MatchDetailsComponent {
  match!: MatchPreview;
  selectedTab: string = 'News';

  statistics : PlayerStatistics[] = []
  opponentStatistics : PlayerStatistics[] = []
  selectedStats !: PlayerStatistics 

  constructor(
    private route: ActivatedRoute,
    public matchService: MatchService
  ) {}

  ngOnInit(): void {
    this.matchService.getByDate(this.getDateFromPath()).subscribe(
      response => {
        this.match = response
        this.matchService.getPlayerStatistics(this.match.id).subscribe(
          response => {
            this.statistics = response.statistics
            this.opponentStatistics = response.opponentStatistics
            this.selectedStats = this.statistics[0] || this.opponentStatistics[0]
          })
    }); 
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

  playerSelected(event:any){
    let hasChanged = false
    this.statistics.forEach(stat => {
      if(stat.id===event.target.value){
        this.selectedStats = stat
        hasChanged = true
      }
    });
    if(!hasChanged){
      this.opponentStatistics.forEach(stat => {
        if(stat.id===event.target.value){
          this.selectedStats = stat
          hasChanged = true
        }
      });
    }
  }
}
