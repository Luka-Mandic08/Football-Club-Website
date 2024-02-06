import { Component, Input } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PlayerForSquad, Squads } from 'src/app/model/players-for-squad';
import { MatchService } from 'src/app/services/match-service.service';
import Swal from 'sweetalert2';
import {CdkDragDrop, CdkDropList, CdkDrag, moveItemInArray, transferArrayItem} from '@angular/cdk/drag-drop';
import { AuthGuardService } from 'src/app/services/auth-guard.service';

@Component({
  selector: 'app-match-squads',
  templateUrl: './match-squads.component.html',
  styleUrls: ['./match-squads.component.css'],
})
export class MatchSquadsComponent {
  @Input() matchId : string = ''
  @Input() opponentName : string = ''
  form : FormGroup
  isAdmin : boolean

  squad : PlayerForSquad[] = []
  subs : PlayerForSquad[] = []
  eligiblePlayers : PlayerForSquad[] = []

  opponentSquad : PlayerForSquad[] = []
  opponentSubs : PlayerForSquad[] = []

  selectedPlayers : PlayerForSquad[] = []

  constructor(public matchService:MatchService,private fb: FormBuilder,private auth: AuthGuardService){
    this.isAdmin = this.auth.isAdmin()
    this.form = this.fb.group({
      name: ['',[Validators.required,Validators.minLength(2),Validators.maxLength(40)]],
      surname: ['',[Validators.required,Validators.minLength(2),Validators.maxLength(40)]],
      number: ['',[Validators.required,this.validateNumber]],
    })
  }

  ngOnInit(){
    this.matchService.getMatchSquads(this.matchId).subscribe(
      response => {
        this.squad = response.squad
        this.subs = response.subs
        this.eligiblePlayers = response.eligiblePlayers
        this.opponentSquad = response.opponentSquad || []
        this.opponentSubs = response.opponentSubs || []
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
      })
  }

  validateNumber = (control:AbstractControl) => {
    let hasError = false
    this.opponentSquad.forEach(p => {
      if (p.squadNumber === control.value){
        hasError = true
      }
    });
    this.opponentSubs.forEach(p => {
      if (p.squadNumber === control.value){
        hasError = true
      }
    });
    if(hasError)
      return { 'numberTaken': { value: control.value } };
    return null;
  }

  isPlayerSelected(player:PlayerForSquad) : boolean {
    let isSelected = false
    this.selectedPlayers.forEach(p => {
      if(p==player){
        isSelected = true
      }
    });
    return isSelected
  }

  selectPlayer(player:PlayerForSquad){
    if(this.isPlayerSelected(player)){
      this.selectedPlayers.forEach((p,index) => {
        if(p==player){
          this.selectedPlayers.splice(index,1)
        }
      });
    }
    else
      this.selectedPlayers.push(player)
  }

  removePlayer(player:PlayerForSquad,fromSubs:boolean){
    if(fromSubs){
      this.subs.forEach((p,index) => {
        if(p==player){
          this.subs.splice(index,1)
        }
      });
    }
    else {
      this.squad.forEach((p,index) => {
        if(p==player){
          this.squad.splice(index,1)
        }
      });
    }
    this.eligiblePlayers.push(player)
  }

  addToSquad(){
    this.selectedPlayers.forEach(player => {
      this.squad.push(player)
      this.eligiblePlayers.forEach((p,index) => {
        if(p==player){
          this.eligiblePlayers.splice(index,1)
        }
      });
    });
    this.selectedPlayers = []
  }

  addToSubs(){
    this.selectedPlayers.forEach(player => {
      this.subs.push(player)
      this.eligiblePlayers.forEach((p,index) => {
        if(p==player){
          this.eligiblePlayers.splice(index,1)
        }
      });
    });
    this.selectedPlayers = []
  }

  addOpponent(toSubs : boolean){
    let player = new PlayerForSquad()
    player.name = this.form.value.name
    player.surname = this.form.value.surname
    player.squadNumber = this.form.value.number
    if(toSubs)
      this.opponentSubs.push(player)
    else
      this.opponentSquad.push(player)
    this.form.reset()
  }

  removeOppositionPlayer(player:PlayerForSquad,fromSubs:boolean){
    if(fromSubs){
      this.opponentSubs.forEach((p,index) => {
        if(p==player){
          this.opponentSubs.splice(index,1)
        }
      });
    }
    else {
      this.opponentSquad.forEach((p,index) => {
        if(p==player){
          this.opponentSquad.splice(index,1)
        }
      });
    }
  }

  drop(event:any) {
    if (event.previousContainer === event.container) {
      if(event.previousContainer.id === "squad")
        moveItemInArray(this.squad, event.previousIndex, event.currentIndex);
      else
        moveItemInArray(this.subs, event.previousIndex, event.currentIndex);
    } else {
      if(event.previousContainer.id === "squad")
        transferArrayItem(this.squad, this.subs, event.previousIndex, event.currentIndex);
      else
        transferArrayItem(this.subs, this.squad, event.previousIndex, event.currentIndex);
    }
  }

  dropOpponent(event:any) {
    if (event.previousContainer === event.container) {
      if(event.previousContainer.id === "opponentSquad")
        moveItemInArray(this.opponentSquad, event.previousIndex, event.currentIndex);
      else
        moveItemInArray(this.opponentSubs, event.previousIndex, event.currentIndex);
    } else {
      if(event.previousContainer.id === "opponentSquad")
        transferArrayItem(this.opponentSquad, this.opponentSubs, event.previousIndex, event.currentIndex);
      else
        transferArrayItem(this.opponentSubs, this.opponentSquad, event.previousIndex, event.currentIndex);
    }
  }


  saveChanges(){
    if(this.squad.length!=11){
      Swal.fire({
        icon: 'warning',
        title: 'Squad size',
        text: "Squad must contain exactly 11 players",
        showConfirmButton: false,
        position: 'bottom-right',
        timer: 3000,
        timerProgressBar: true,
        backdrop: 'none',
        width: 300,
        background: 'rgb(45,45,148)',
        color: 'white',
      })
      return
    }
    this.matchService.updateMatchSquads(this.matchId,this.createDto()).subscribe(
      response => {
          Swal.fire({
            icon: 'success',
            title: 'Success',
            text: "Squads successfully updated",
            showConfirmButton: false,
            position: 'bottom-right',
            timer: 3000,
            timerProgressBar: true,
            backdrop: 'none',
            width: 300,
            background: 'rgb(45,45,148)',
            color: 'white',
          });
          this.squad = response.squad;
          this.subs = response.subs
          this.eligiblePlayers = response.eligiblePlayers
          this.opponentSquad = response.opponentSquad
          this.opponentSubs = response.opponentSubs
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
        })
  }

  createDto() :Squads{
    let dto = new Squads()
    dto.squad = this.squad
    dto.subs = this.subs
    dto.eligiblePlayers = this.eligiblePlayers
    dto.opponentSquad = this.opponentSquad
    dto.opponentSubs = this.opponentSubs
    return dto
  }

}
