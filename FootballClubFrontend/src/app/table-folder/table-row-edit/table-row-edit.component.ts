import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable, Subscription } from 'rxjs';
import { TableRow } from 'src/app/model/table';

@Component({
  selector: 'app-table-row-edit',
  templateUrl: './table-row-edit.component.html',
  styleUrls: ['./table-row-edit.component.css']
})
export class TableRowEditComponent {

  @Input() row !: TableRow
  @Output() updateEvent = new EventEmitter<TableRow>();
  @Output() deleteEvent = new EventEmitter<TableRow>();
  form !: FormGroup

  constructor(private fb:FormBuilder){}

  ngOnInit(){
    this.form = this.fb.group({
      team: [this.row.team,[Validators.required,Validators.minLength(3),Validators.maxLength(40)]],
      wins: [this.row.wins,[Validators.required]],
      draws: [this.row.draws,[Validators.required]],
      losses: [this.row.losses,[Validators.required]],
      goalDifference: [this.row.goalDifference,[Validators.required]],
      points: [this.row.points,[Validators.required]],
    })

    this.form.valueChanges.subscribe((formValues) => {
      this.row = { ...this.row, ...formValues };
      
    });
  }

  lostFocus(){
    if(this.form.valid)
      this.updateEvent.emit(this.row)
  }

  deleteRow(){
    this.deleteEvent.emit(this.row)
  }
  
}
