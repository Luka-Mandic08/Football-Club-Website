import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PlayerDto } from 'src/app/model/player';
import { AuthGuardService } from 'src/app/services/auth-guard.service';
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

  isAdmin : boolean

  constructor(private router: Router,public playerService: PlayerService,private auth:AuthGuardService) {
    this.isAdmin = this.auth.isAdmin()
   }

  ngOnInit(){
    this.playerService.getActiveAndLoaned().subscribe(
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

  newPlayer(){
    this.router.navigateByUrl('players/create')
  }
}
