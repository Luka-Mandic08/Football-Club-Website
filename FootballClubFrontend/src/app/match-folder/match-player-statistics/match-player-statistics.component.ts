import { Component, Input } from '@angular/core';
import { PlayerStatistics } from 'src/app/model/player-statistics';
import { MatchService } from 'src/app/services/match-service.service';

@Component({
  selector: 'app-match-player-statistics',
  templateUrl: './match-player-statistics.component.html',
  styleUrls: ['./match-player-statistics.component.css']
})
export class MatchPlayerStatisticsComponent {
  @Input() selectedStats !: PlayerStatistics
  @Input() opponentName : string = ''

  selectedTab: string = 'General'; 

  constructor(public matchService : MatchService) { }

  ngOnChanges(): void {
    this.selectedTab = 'General'
  }

  selectTab(tab: string) {
    this.selectedTab = tab;
  }

  calculateStat(stat : string) : number|undefined{
    switch(stat){
      case "passes" : return Math.round(this.selectedStats.passingStatistics.completedPasses / this.selectedStats.passingStatistics.totalPasses * 1000)/10
      case "longPasses" : return Math.round(this.selectedStats.passingStatistics.completedLongPasses / this.selectedStats.passingStatistics.totalLongPasses * 1000)/10
    }
    if(this.selectedStats.defendingStatistics)
      switch(stat){
        case "tackles": return Math.round(this.selectedStats.defendingStatistics.successfulTackles / this.selectedStats.defendingStatistics.totalTackles * 1000)/10
        case "aerialDuels": return Math.round(this.selectedStats.defendingStatistics.successfulAerialDuels / this.selectedStats.defendingStatistics.totalAerialDuels * 1000)/10
        case "groundDuels": return Math.round(this.selectedStats.defendingStatistics.successfulGroundDuels / this.selectedStats.defendingStatistics.totalGroundDuels * 1000)/10
      }      
    return 0;
  }
  
}
