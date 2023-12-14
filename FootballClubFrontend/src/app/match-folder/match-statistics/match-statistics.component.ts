import { Component, Input } from '@angular/core';
import { MatchStatistics } from 'src/app/model/match-statistics';
import { PlayerStatistics } from 'src/app/model/player-statistics';
import { MatchService } from 'src/app/services/match-service.service';

@Component({
  selector: 'app-match-statistics',
  templateUrl: './match-statistics.component.html',
  styleUrls: ['./match-statistics.component.css']
})
export class MatchStatisticsComponent {
  @Input() matchId : string = ''
  @Input() opponentName : string = ''
  @Input() isHomeGame : boolean = true

  statistics !: MatchStatistics
  opponentStatistics !: MatchStatistics

  selectedTab: string = 'General';

  constructor(public matchService : MatchService) { }

  ngOnInit(){
    this.matchService.getMatchStatistics(this.matchId).subscribe(
      response => {
        if(this.isHomeGame){
          this.statistics = response.statistics
          this.opponentStatistics = response.opponentStatistics
        }
        else
        {
          this.statistics = response.opponentStatistics
          this.opponentStatistics = response.statistics
        }
      }
    )
  }

  selectTab(tab: string) {
    this.selectedTab = tab;
  }
}
