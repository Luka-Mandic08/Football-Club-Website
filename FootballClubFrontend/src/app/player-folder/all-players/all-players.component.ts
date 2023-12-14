import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PlayerDto } from 'src/app/model/player';
import { PlayerService } from 'src/app/services/player-service.service';

@Component({
  selector: 'app-all-players',
  templateUrl: './all-players.component.html',
  styleUrls: ['./all-players.component.css']
})
export class AllPlayersComponent {
  
  goalkeepers : PlayerDto[] = []
  defenders : PlayerDto[] = []
  midfielders : PlayerDto[] = []
  attackers : PlayerDto[] = []
  loanedPlayers : PlayerDto[] = []

  constructor(private router: Router,public playerService: PlayerService) { }

  ngOnInit(){
    this.playerService.getAllPlayers().subscribe(
      response => {
        this.loanedPlayers = response.loanedPlayers
        response.activePlayers.forEach(player => {
          switch(player.position){
            case 0 : this.goalkeepers.push(player); break;
            case 1 : this.defenders.push(player); break;
            case 2 : this.midfielders.push(player); break;
            case 3 : this.attackers.push(player); break;
          }
        });
      }
    )
  }

  route(player : PlayerDto){
    const navigationExtras = {
      state: {
        id: player.id,
      },
    };
    this.router.navigate(['players/' + player.name + '-' + player.surname],navigationExtras)
  }
}
