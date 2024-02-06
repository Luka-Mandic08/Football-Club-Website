import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatchService } from '../../services/match-service.service';
import { MatchPreview } from 'src/app/model/match';
import { PlayerStatistics } from 'src/app/model/player-statistics';
import { ArticleService } from 'src/app/services/article-service.service';
import { Article } from 'src/app/model/article';
import { AuthGuardService } from 'src/app/services/auth-guard.service';

@Component({
  selector: 'app-match-details',
  templateUrl: './match-details.component.html',
  styleUrls: ['./match-details.component.css'],
})
export class MatchDetailsComponent {
  match!: MatchPreview;
  selectedTab: string = 'News';
  isAdmin !: boolean

  statistics : PlayerStatistics[] = []
  opponentStatistics : PlayerStatistics[] = []
  selectedStats !: PlayerStatistics 
  articles : Article[] = []

  constructor(
    private route: ActivatedRoute,
    private auth: AuthGuardService,
    public matchService: MatchService,
    public articleService: ArticleService
  ) {}

  ngOnInit(): void {
    this.isAdmin = this.auth.isAdmin()
    this.matchService.getByDate(this.getDateFromPath()).subscribe(
      response => {
        this.match = response
        this.matchService.getPlayerStatistics(this.match.id).subscribe(
          response => {
            this.statistics = response.statistics
            this.opponentStatistics = response.opponentStatistics
            this.selectedStats = this.statistics[0] || this.opponentStatistics[0]
          })
        this.articleService.getForMatch(this.match.id).subscribe(
          response => {
            this.articles = response
          }
        )
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
