import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GetStatisticsForPlayerDto, PlayerDto } from 'src/app/model/player';
import { PlayerStatistics } from 'src/app/model/player-statistics';
import { PlayerService } from 'src/app/services/player-service.service';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent {

  player !: PlayerDto
  name : string = ''
  id !: string|null
  selectedYear : number = 2023
  selectedCompetition : string = 'Premier league'
  playerStats !: PlayerStatistics 

  constructor(private router: Router, private route: ActivatedRoute, public playerService : PlayerService) {
    const state = this.router.getCurrentNavigation()?.extras.state as {
      id: string,
    };
    if(state?.id)
      this.id = state.id
    let name = this.route.snapshot.paramMap.get('name')
    if(name!==null)
      this.name = name
    
  }

  ngOnInit() {
    if(this.id){
      this.playerService.getPlayerById(this.id).subscribe(
        response => {
          this.player = response
        }
      )
    }
    else{
      this.playerService.getPlayerByName(this.name).subscribe(
        response => {
          this.player = response
        }
      )
    }

    this.playerService.getStatisticsForPlayer(new GetStatisticsForPlayerDto(this.id,this.name,this.selectedCompetition,this.selectedYear)).subscribe(
      response => {
        this.playerStats = response
      }
    )
  }

  formatDate(date:Date) : string{
    date = new Date(date)
    let formatedDate = ''
    formatedDate += date.getDate() + '.' + date.getMonth() + '.' + date.getFullYear() + '.'
    return formatedDate
  }

  formatPosition(position:Number):string{
    switch(position){
      case 0: return "Goalkeeper";
      case 1: return "Defender";
      case 2: return "Midfielder";
      case 3: return "Forward";
      default: return ""
    }
  }

  formatStatus(status:Number):string{
    switch(status){
      case 0: return "Active";
      case 1: return "No longer at club";
      case 2: return "On loan";
      default: return ""
    }
  }

  selectCompetition(event:any){
    this.selectedCompetition = event.target.value
  }

  selectYer(event:any){
    this.selectedYear = event.target.value
  }
}
