import { Component, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PlayerStatistics, PlayerStatisticsDto } from 'src/app/model/player-statistics';
import { PlayerForSquad, Squads } from 'src/app/model/players-for-squad';
import { MatchService } from 'src/app/services/match-service.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-match-player-statistics-edit',
  templateUrl: './match-player-statistics-edit.component.html',
  styleUrls: ['./match-player-statistics-edit.component.css']
})
export class MatchPlayerStatisticsEditComponent {
  @Input() matchId = ''
  @Input() competition = ''
  @Input() season = 0
  @Input() opponentName = ''

  attackingForm : FormGroup
  defendingForm : FormGroup
  passingForm : FormGroup
  goalkeepingForm : FormGroup
  generalForm : FormGroup

  completeSquad : PlayerForSquad[] = []
  oppositionCompleteSquad : PlayerForSquad[] = []

  existingStatistics : PlayerStatistics[] = []

  selectedPlayerId : string = ''
  isSelectedPlayerGoalkeeper : boolean = false

  constructor(private fb: FormBuilder, public matchService: MatchService){
    this.attackingForm = this.fb.group({
      totalGoals: ['', [Validators.required]],
      totalShots: ['', [Validators.required]],
      shotsOnTarget: ['', [Validators.required]],
      rightFootedGoals: ['', [Validators.required]],
      leftFootedGoals: ['', [Validators.required]],
      headedGoals: ['', [Validators.required]],
      freekickGoals: ['', [Validators.required]],
      assists: ['', [Validators.required]]
    });
    this.attackingForm.disable()
    
    this.defendingForm = this.fb.group({
      clearances: ['', [Validators.required]],
      blocks: ['', [Validators.required]],
      interceptions: ['', [Validators.required]],
      successfulTackles: ['', [Validators.required]],
      totalTackles: ['', [Validators.required]],
      successfulAerialDuels: ['', [Validators.required]],
      totalAerialDuels: ['', [Validators.required]],
      successfulGroundDuels: ['', [Validators.required]],
      totalGroundDuels: ['', [Validators.required]]
    });
    this.defendingForm.disable()
    
    this.passingForm = this.fb.group({
      totalPasses: ['', [Validators.required]],
      completedPasses: ['', [Validators.required]],
      totalLongPasses: ['', [Validators.required]],
      completedLongPasses: ['', [Validators.required]],
      completedCrosses: ['', [Validators.required]],
      secondAssists: ['', [Validators.required]],
      keyPasses: ['', [Validators.required]]
    });
    this.passingForm.disable()
    
    this.goalkeepingForm = this.fb.group({
      numberOfSaves: ['', [Validators.required]],
      numberOfShotsFaced: ['', [Validators.required]],
      cleanSheets: ['', [Validators.required]],
      penaltiesSaved: ['', [Validators.required]],
      catches: ['', [Validators.required]],
    });
    this.goalkeepingForm.disable()
    
    this.generalForm = this.fb.group({
      gamesPlayed: [1],
      minutesPlayed: ['', [Validators.required]],
      foulsWon: ['', [Validators.required]],
      foulsConceded: ['', [Validators.required]],
      yellowCards: ['', [Validators.required]],
      redCards: ['', [Validators.required]]
    });
    this.generalForm.disable()
  }

  ngOnInit(){
    this.matchService.getMatchSquads(this.matchId).subscribe(
      response => {
        this.completeSquad = response.squad.concat(response.subs)
        this.oppositionCompleteSquad = response.opponentSquad.concat(response.opponentSubs)
      }
    )
    this.matchService.getPlayerStatistics(this.matchId).subscribe(
      (response : PlayerStatisticsDto) => {
        this.existingStatistics = response.statistics.concat(response.opponentStatistics)
      }
    )
  }

  playerSelected(event:any){
    let shouldChange = false
    this.enableForms()
    if(this.generalForm.dirty || this.passingForm.dirty || this.attackingForm.dirty || this.defendingForm.dirty || this.goalkeepingForm.dirty)
      {
        Swal.fire({
          title: "Are you sure?",
          text: "Changing players will reset all forms",
          icon: "warning",
          showCancelButton: true,
          confirmButtonColor: "#3085d6",
          cancelButtonColor: "#d33",
          confirmButtonText: "Confirm"
        }).then((result) => {
          shouldChange = result.isConfirmed
          if(shouldChange){
            this.selectedPlayerId = event.target.value
            this.fillForms()
          }
          else {
            event.target.value = this.selectedPlayerId
          }
        });
      }
      else {
        this.selectedPlayerId = event.target.value
        this.fillForms()
      }
  }

  fillForms(){
    let shouldResetForms = true
    this.existingStatistics.forEach(statistics => {
      if(statistics.playerId === this.selectedPlayerId){
        shouldResetForms = false
        this.generalForm.setValue(statistics.generalStatistics)
        this.passingForm.setValue(statistics.passingStatistics)
        if(statistics.attackingStatistics)
          this.attackingForm.setValue(statistics.attackingStatistics)
        else
          this.attackingForm.reset()
        if(statistics.defendingStatistics)
          this.defendingForm.setValue(statistics.defendingStatistics)
        else
          this.defendingForm.reset()
        if(statistics.goalkeepingStatistics)
          this.goalkeepingForm.setValue(statistics.goalkeepingStatistics) 
        else
          this.goalkeepingForm.reset()  
      }
    })
    if(shouldResetForms){
      this.generalForm.reset()
      this.attackingForm.reset()
      this.defendingForm.reset()
      this.goalkeepingForm.reset()
      this.passingForm.reset()
    }
  }

  enableForms(){
    this.generalForm.enable()
    this.passingForm.enable()
    this.attackingForm.enable()
    this.defendingForm.enable()
    this.goalkeepingForm.enable()
  }


  boxChecked(){
    this.isSelectedPlayerGoalkeeper = !this.isSelectedPlayerGoalkeeper
  }

  areFormsValid() : boolean {
    return this.generalForm.valid && this.passingForm.valid && this.selectedPlayerId!=='' &&
    ((this.attackingForm.valid && this.defendingForm.valid && !this.isSelectedPlayerGoalkeeper) || (this.goalkeepingForm.valid && this.isSelectedPlayerGoalkeeper))
  }
  
  onSubmit(){
    this.matchService.updatePlayerStatistics(this.createDto()).subscribe(
      response => {
        this.generalForm.markAsPristine()
        this.passingForm.markAsPristine()
        this.attackingForm.markAsPristine()
        this.defendingForm.markAsPristine()
        this.goalkeepingForm.markAsPristine()
        this.existingStatistics = response.statistics.concat(response.opponentStatistics)
        Swal.fire({
          icon: 'success',
          title: 'Success',
          text: "Stats successfully updated",
          showConfirmButton: false,
          position: 'bottom-right',
          timer: 3000,
          timerProgressBar: true,
          backdrop: 'none',
          width: 300,
          background: 'rgb(45,45,148)',
          color: 'white',
        });
      },
      (error) => {
        Swal.fire({
          icon: 'error',
          title: 'Error',
          text: error.error.message,
          showConfirmButton: false,
          position: 'bottom-right',
          timer: 3000,
          timerProgressBar: true,
          backdrop: 'none',
          width: 300,
          background: 'rgb(45,45,148)',
          color: 'white',
        });
      }
    )
  }

  createDto() : PlayerStatistics {
    let statistics : PlayerStatistics = new PlayerStatistics
    if(this.isSelectedPlayerGoalkeeper){
      statistics.attackingStatistics = null
      statistics.defendingStatistics = null
      statistics.goalkeepingStatistics = {...this.goalkeepingForm.value}
    }
    else{
      statistics.attackingStatistics = {...this.attackingForm.value}
      statistics.defendingStatistics = {...this.defendingForm.value}
      statistics.goalkeepingStatistics = null
    }  
    statistics.passingStatistics = {...this.passingForm.value} 
    statistics.generalStatistics = {...this.generalForm.value}
    statistics.generalStatistics.gamesPlayed = 1
    statistics.matchId = this.matchId
    statistics.competition = this.competition
    statistics.season = this.season  
    statistics.playerId = this.selectedPlayerId
    this.completeSquad.forEach(player => {
      if(player.id === this.selectedPlayerId){
        statistics.playerName = player.name + ' ' + player.surname
        statistics.team = "FK FTN"
      }
    });
    if(statistics.playerName === undefined || statistics.playerName === ""){
      this.oppositionCompleteSquad.forEach(player => {
        if(player.id === this.selectedPlayerId){
          statistics.playerName = player.name + ' ' + player.surname
          statistics.team = this.opponentName
        }
      });
    }
    statistics.id = null
    this.existingStatistics.forEach(s => {
      if(s.playerId === this.selectedPlayerId){
        statistics.id = s.id
      }
    });    
    return statistics
  }
}
