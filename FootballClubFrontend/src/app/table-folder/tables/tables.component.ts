import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Table } from 'src/app/model/table';
import { TableService } from 'src/app/services/table-service.service';

@Component({
  selector: 'app-tables',
  templateUrl: './tables.component.html',
  styleUrls: ['./tables.component.css']
})
export class TablesComponent {

  tables : Table[] = []
  selectedTable !: Table

  constructor(public tableService:TableService,private router:Router){

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

  routeToEdit(){
    this.router.navigateByUrl('tables/edit');
  }

  deleteTable(){
    this.tableService.delete(this.selectedTable.id)
  }

}
