import { Component, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatchService} from '../services/match-service.service';

@Component({
  selector: 'app-create-match',
  templateUrl: './create-match.component.html',
  styleUrls: ['./create-match.component.css']
})
export class CreateMatchComponent {
  
  form : FormGroup;

  constructor(private fb: FormBuilder,private matchService:MatchService) {
    this.form = this.fb.group({
      opponent: ['',[Validators.required,Validators.minLength(2)]],
      venue: ['',Validators.required],
      referee: ['',Validators.required],
      competition: ['',Validators.required],
      start: [null,Validators.required]
    })
  }

  onSubmit() {
    if (this.form.valid) {
      console.log('Form submitted with data:', this.form);
      this.matchService.createMatch(this.form.value).subscribe(
        response => {
          console.log(response)
      },
      error => {
        alert(error)
      })
    }
    else{
      console.log('Invalid form')
    }
  }
}
