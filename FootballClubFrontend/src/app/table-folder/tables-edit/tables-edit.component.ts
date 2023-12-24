import { moveItemInArray } from '@angular/cdk/drag-drop';
import { Component, ViewChild } from '@angular/core';
import { Subject } from 'rxjs';
import { CreateTableDto, Table, TableRow } from 'src/app/model/table';
import { TableService } from 'src/app/services/table-service.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-tables-edit',
  templateUrl: './tables-edit.component.html',
  styleUrls: ['./tables-edit.component.css']
})
export class TablesEditComponent {
  tables : Table[] = []
  selectedTable !: Table 

  inputCompetition : string = ''
  inputSeason : number = 2023

  constructor(public tableService:TableService){

  }

  eventsSubject: Subject<void> = new Subject<void>();
  emitEventToChild() {
    this.eventsSubject.next();
  }

  ngOnInit(){
    this.tableService.getAllBySeason(this.getCurrentSeason()).subscribe(
      response => {
        this.tables = response
        if(this.tables.length>0)
          this.selectedTable = this.tables[0]
      }
    )
  }

  getCurrentSeason():number{
    let date = new Date()
    return date.getMonth()<6?date.getFullYear()-1:date.getFullYear()
  }

  competitionSelected(event:any){
    this.tables.forEach(table => {
      if(table.id===event.target.value)
        this.selectedTable = table
    });
  }

  seasonSelected(event:any){
    const season = parseInt(event.target.value.split("/")[0])
    this.tableService.getAllBySeason(season).subscribe(
      response => {
        this.tables = response
        if(this.tables.length>0)
          this.selectedTable = this.tables[0]
        else
          this.selectedTable = new Table()
      }
    )
  }

  addNewTable(){
    let table = new CreateTableDto()
    table.competition = this.inputCompetition
    table.season = this.inputSeason
    let tableRow = new TableRow()
    tableRow.team = "FK FTN"
    tableRow.position = 1
    table.rows.push(tableRow)
    this.tableService.createTable(table).subscribe(
      response => {
        this.tables = response
      }
    )
  }

  addNewRow(){
    let tableRow = new TableRow()
    tableRow.position = this.selectedTable.rows.length+1
    this.selectedTable.rows.push(tableRow)
    this.updateTable()
  }

  drop(event:any) {
    moveItemInArray(this.selectedTable.rows, event.previousIndex, event.currentIndex);
    this.updateRowOrder()
  }

  updateRow(updatedRow: TableRow){
    this.selectedTable.rows.forEach((row,index) => {
      if(updatedRow.id===row.id)
      this.selectedTable.rows[index] = updatedRow
    });
  }

  deleteRow(updatedRow: TableRow){
    this.selectedTable.rows.forEach((row,index) => {
      if(updatedRow.id===row.id)
      this.selectedTable.rows.splice(index,1)
    });
  }

  updateTable(){
    if(!this.updateRowOrder())
      Swal.fire({
        icon: 'warning',
        title: 'Unable to update table',
        text: "Points and positions are not aligned",
        showConfirmButton: false,
        position: 'bottom-right',
        timer: 5000,
        timerProgressBar: true,
        backdrop: 'none',
        width: 300,
        background: 'rgb(45,45,148)',
        color: 'white',
      });
    else{
      this.emitEventToChild()
      this.tableService.update(this.selectedTable).subscribe(
        response => {
          let previousIndex = this.mySelect.nativeElement.selectedIndex
          this.tables = response
          this.mySelect.nativeElement.selectedIndex = previousIndex
        }
      )
    }
  }

  @ViewChild('selectTableElement') mySelect: any; // ViewChild to get a reference to the select element

  setSelectedOptionByIndex(index: number) {
    
  }

  updateRowOrder() : Boolean{
    let isCorrect = true
    let previosPoints = this.selectedTable.rows[0].points
    let previosGoalDifference = this.selectedTable.rows[0].goalDifference
    this.selectedTable.rows.forEach((row,index) => {
      row.position = index + 1
      if(row.points>previosPoints || (row.points==previosPoints && row.goalDifference>previosGoalDifference))
        isCorrect = false
      else{
        previosPoints = row.points
        previosGoalDifference = row.goalDifference
      }
    });
    return isCorrect
  }
}
