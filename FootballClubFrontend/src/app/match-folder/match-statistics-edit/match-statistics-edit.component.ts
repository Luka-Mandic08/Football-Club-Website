import { Component, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AttackingMatchStatistics, DefendingMatchStatistics, GeneralMatchStatistics, MatchStatistics, MatchStatisticsDto, PassingMatchStatistics } from 'src/app/model/match-statistics';
import { MatchService } from 'src/app/services/match-service.service';

@Component({
  selector: 'app-match-statistics-edit',
  templateUrl: './match-statistics-edit.component.html',
  styleUrls: ['./match-statistics-edit.component.css']
})
export class MatchStatisticsEditComponent {

    @Input() matchId: string = ''

    statistics !: MatchStatistics
    opponentStatistics !: MatchStatistics

    statisticsForm !: FormGroup;
    opponentStatisticsForm !: FormGroup;

    constructor(private fb: FormBuilder, public matchService: MatchService){    }

    ngOnInit(){
      this.matchService.getMatchStatistics(this.matchId).subscribe(
        response => {
          this.statistics = response.statistics
          this.opponentStatistics = response.opponentStatistics

          this.statisticsForm = this.fb.group({
            possession: [this.statistics?.generalMatchStatistics.possession,[Validators.required]],
            duelSuccessRate: [this.statistics?.generalMatchStatistics.duelSuccessRate,[Validators.required]],
            aerialDuelSuccessRate: [this.statistics?.generalMatchStatistics.aerialDuelSuccessRate,[Validators.required]],
            interceptions: [this.statistics?.generalMatchStatistics.interceptions,[Validators.required]],
            offsides: [this.statistics?.generalMatchStatistics.offsides,[Validators.required]],
            corners: [this.statistics?.generalMatchStatistics.corners,[Validators.required]],
            
            goals: [this.statistics?.attackingMatchStatistics.goals,[Validators.required]],
            shots: [this.statistics?.attackingMatchStatistics.shots,[Validators.required]],
            shotsOnTarget: [this.statistics?.attackingMatchStatistics.shotsOnTarget,[Validators.required]],
            blockedShots: [this.statistics?.attackingMatchStatistics.blockedShots,[Validators.required]],
            shotsOutsideTheBox: [this.statistics?.attackingMatchStatistics.shotsOutsideTheBox,[Validators.required]],
            shotsInsideTheBox: [this.statistics?.attackingMatchStatistics.shotsInsideTheBox,[Validators.required]],
            shootingAccuracy: [this.statistics?.attackingMatchStatistics.shootingAccuracy,[Validators.required]],
            
            passes: [this.statistics?.passingMatchStatistics.passes,[Validators.required]],
            longPasses: [this.statistics?.passingMatchStatistics.longPasses,[Validators.required]],
            passingAccuracy: [this.statistics?.passingMatchStatistics.passingAccuracy,[Validators.required]],
            passingAccuracyInOpponentsHalf: [this.statistics?.passingMatchStatistics.passingAccuracyInOpponentsHalf,[Validators.required]],
            crosses: [this.statistics?.passingMatchStatistics.crosses,[Validators.required]],
            crossingAccuracy: [this.statistics?.passingMatchStatistics.crossingAccuracy,[Validators.required]],
    
            tackles: [this.statistics?.defendingMatchStatistics.tackles,[Validators.required]],
            tackleSuccessRate: [this.statistics?.defendingMatchStatistics.tackleSuccessRate,[Validators.required]],
            clearances: [this.statistics?.defendingMatchStatistics.clearances,[Validators.required]],
            yellowCards: [this.statistics?.defendingMatchStatistics.yellowCards,[Validators.required]],
            redCards: [this.statistics?.defendingMatchStatistics.redCards,[Validators.required]],
            fouls: [this.statistics?.defendingMatchStatistics.fouls,[Validators.required]],
          })
    
          this.opponentStatisticsForm = this.fb.group({
            possession: [this.opponentStatistics?.generalMatchStatistics.possession,[Validators.required]],
            duelSuccessRate: [this.opponentStatistics?.generalMatchStatistics.duelSuccessRate,[Validators.required]],
            aerialDuelSuccessRate: [this.opponentStatistics?.generalMatchStatistics.aerialDuelSuccessRate,[Validators.required]],
            interceptions: [this.opponentStatistics?.generalMatchStatistics.interceptions,[Validators.required]],
            offsides: [this.opponentStatistics?.generalMatchStatistics.offsides,[Validators.required]],
            corners: [this.opponentStatistics?.generalMatchStatistics.corners,[Validators.required]],
            
            goals: [this.opponentStatistics?.attackingMatchStatistics.goals,[Validators.required]],
            shots: [this.opponentStatistics?.attackingMatchStatistics.shots,[Validators.required]],
            shotsOnTarget: [this.opponentStatistics?.attackingMatchStatistics.shotsOnTarget,[Validators.required]],
            blockedShots: [this.opponentStatistics?.attackingMatchStatistics.blockedShots,[Validators.required]],
            shotsOutsideTheBox: [this.opponentStatistics?.attackingMatchStatistics.shotsOutsideTheBox,[Validators.required]],
            shotsInsideTheBox: [this.opponentStatistics?.attackingMatchStatistics.shotsInsideTheBox,[Validators.required]],
            shootingAccuracy: [this.opponentStatistics?.attackingMatchStatistics.shootingAccuracy,[Validators.required]],
            
            passes: [this.opponentStatistics?.passingMatchStatistics.passes,[Validators.required]],
            longPasses: [this.opponentStatistics?.passingMatchStatistics.longPasses,[Validators.required]],
            passingAccuracy: [this.opponentStatistics?.passingMatchStatistics.passingAccuracy,[Validators.required]],
            passingAccuracyInOpponentsHalf: [this.opponentStatistics?.passingMatchStatistics.passingAccuracyInOpponentsHalf,[Validators.required]],
            crosses: [this.opponentStatistics?.passingMatchStatistics.crosses,[Validators.required]],
            crossingAccuracy: [this.opponentStatistics?.passingMatchStatistics.crossingAccuracy,[Validators.required]],
    
            tackles: [this.opponentStatistics?.defendingMatchStatistics.tackles,[Validators.required]],
            tackleSuccessRate: [this.opponentStatistics?.defendingMatchStatistics.tackleSuccessRate,[Validators.required]],
            clearances: [this.opponentStatistics?.defendingMatchStatistics.clearances,[Validators.required]],
            yellowCards: [this.opponentStatistics?.defendingMatchStatistics.yellowCards,[Validators.required]],
            redCards: [this.opponentStatistics?.defendingMatchStatistics.redCards,[Validators.required]],
            fouls: [this.opponentStatistics?.defendingMatchStatistics.fouls,[Validators.required]],
          })
        }
      )
    }

    onSubmit() {
      if (this.statisticsForm.valid && this.opponentStatisticsForm.valid) {
        let dto = this.createDto()
        console.log(dto)
        this.matchService.updateMatchStatistics(this.matchId,dto).subscribe(
          response => console.log(response)
        )
        }
      else{
        console.log('Invalid form')
      }
    }

    possessionChange(event:Event){
      let elementId: string = (event.target as Element).id
      if(elementId==='possession')
        this.opponentStatisticsForm.controls['possession'].setValue(Math.round(10*(100-this.statisticsForm.value.possession))/10)
      else
        this.statisticsForm.controls['possession'].setValue(Math.round(10*(100-this.opponentStatisticsForm.value.possession))/10)
    }

    duelSuccessRateChange(event:Event){
      let elementId: string = (event.target as Element).id
      if(elementId==='duelSuccessRate')
        this.opponentStatisticsForm.controls['duelSuccessRate'].setValue(Math.round(10*(100-this.statisticsForm.value.duelSuccessRate))/10)
      else
        this.statisticsForm.controls['duelSuccessRate'].setValue(Math.round(10*(100-this.opponentStatisticsForm.value.duelSuccessRate))/10)
    }

    aerialDuelSuccessRateChange(event:Event){
      let elementId: string = (event.target as Element).id
      if(elementId==='aerialDuelSuccessRate')
        this.opponentStatisticsForm.controls['aerialDuelSuccessRate'].setValue(Math.round(10*(100-this.statisticsForm.value.aerialDuelSuccessRate))/10)
      else
        this.statisticsForm.controls['aerialDuelSuccessRate'].setValue(Math.round(10*(100-this.opponentStatisticsForm.value.aerialDuelSuccessRate))/10)
    }

    goalChange(event:Event){

    }

    createDto(){
      let generalMatchStatistics : GeneralMatchStatistics = {
        possession : this.statisticsForm.value.possession,
        duelSuccessRate : this.statisticsForm.value.duelSuccessRate,
        aerialDuelSuccessRate : this.statisticsForm.value.aerialDuelSuccessRate,
        interceptions : this.statisticsForm.value.interceptions,
        offsides : this.statisticsForm.value.offsides,
        corners : this.statisticsForm.value.corners,
      }
      
      let attackingMatchStatistics : AttackingMatchStatistics = {
        goals : this.statisticsForm.value.goals,
        shots : this.statisticsForm.value.shots,
        shotsOnTarget : this.statisticsForm.value.shotsOnTarget,
        blockedShots : this.statisticsForm.value.blockedShots,
        shotsOutsideTheBox : this.statisticsForm.value.shotsOutsideTheBox,
        shotsInsideTheBox : this.statisticsForm.value.shotsInsideTheBox,
        shootingAccuracy : this.statisticsForm.value.shootingAccuracy,
      }
      
      let passingMatchStatistics : PassingMatchStatistics = {
        passes : this.statisticsForm.value.passes,
        longPasses : this.statisticsForm.value.longPasses,
        passingAccuracy : this.statisticsForm.value.passingAccuracy,
        passingAccuracyInOpponentsHalf : this.statisticsForm.value.passingAccuracyInOpponentsHalf,
        crosses : this.statisticsForm.value.crosses,
        crossingAccuracy : this.statisticsForm.value.crossingAccuracy,
      }

      let defendingMatchStatistics : DefendingMatchStatistics = {
        tackles : this.statisticsForm.value.tackles,
        tackleSuccessRate : this.statisticsForm.value.tackleSuccessRate,
        clearances : this.statisticsForm.value.clearances,
        yellowCards : this.statisticsForm.value.yellowCards,
        redCards : this.statisticsForm.value.redCards,
        fouls : this.statisticsForm.value.fouls,
      }

      let statistics : MatchStatistics = {
        generalMatchStatistics : generalMatchStatistics,
        attackingMatchStatistics : attackingMatchStatistics,
        passingMatchStatistics : passingMatchStatistics,
        defendingMatchStatistics: defendingMatchStatistics,
      }

      let opponentGeneralMatchStatistics : GeneralMatchStatistics = {
        possession : this.opponentStatisticsForm.value.possession,
        duelSuccessRate : this.opponentStatisticsForm.value.duelSuccessRate,
        aerialDuelSuccessRate : this.opponentStatisticsForm.value.aerialDuelSuccessRate,
        interceptions : this.opponentStatisticsForm.value.interceptions,
        offsides : this.opponentStatisticsForm.value.offsides,
        corners : this.opponentStatisticsForm.value.corners,
      }
      
      let opponentAttackingMatchStatistics : AttackingMatchStatistics = {
        goals : this.opponentStatisticsForm.value.goals,
        shots : this.opponentStatisticsForm.value.shots,
        shotsOnTarget : this.opponentStatisticsForm.value.shotsOnTarget,
        blockedShots : this.opponentStatisticsForm.value.blockedShots,
        shotsOutsideTheBox : this.opponentStatisticsForm.value.shotsOutsideTheBox,
        shotsInsideTheBox : this.opponentStatisticsForm.value.shotsInsideTheBox,
        shootingAccuracy : this.opponentStatisticsForm.value.shootingAccuracy,
      }
      
      let opponentPassingMatchStatistics : PassingMatchStatistics = {
        passes : this.opponentStatisticsForm.value.passes,
        longPasses : this.opponentStatisticsForm.value.longPasses,
        passingAccuracy : this.opponentStatisticsForm.value.passingAccuracy,
        passingAccuracyInOpponentsHalf : this.opponentStatisticsForm.value.passingAccuracyInOpponentsHalf,
        crosses : this.opponentStatisticsForm.value.crosses,
        crossingAccuracy : this.opponentStatisticsForm.value.crossingAccuracy,
      }

      let opponentDefendingMatchStatistics : DefendingMatchStatistics = {
        tackles : this.opponentStatisticsForm.value.tackles,
        tackleSuccessRate : this.opponentStatisticsForm.value.tackleSuccessRate,
        clearances : this.opponentStatisticsForm.value.clearances,
        yellowCards : this.opponentStatisticsForm.value.yellowCards,
        redCards : this.opponentStatisticsForm.value.redCards,
        fouls : this.opponentStatisticsForm.value.fouls,
      }

      let opponentStatistics : MatchStatistics = {
        generalMatchStatistics : opponentGeneralMatchStatistics,
        attackingMatchStatistics : opponentAttackingMatchStatistics,
        passingMatchStatistics : opponentPassingMatchStatistics,
        defendingMatchStatistics: opponentDefendingMatchStatistics,
      }

      let dto : MatchStatisticsDto = {
        statistics : statistics,
        opponentStatistics : opponentStatistics
      }

      return dto
    }
}
