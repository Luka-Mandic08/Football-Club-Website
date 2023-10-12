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
      opponent: ['',[Validators.required,Validators.minLength(2),Validators.maxLength(40)]],
      venue: ['',[Validators.required,Validators.minLength(2),Validators.maxLength(40)]],
      referee: ['',[Validators.required,Validators.minLength(2),Validators.maxLength(40)]],
      competition: ['',[Validators.required,Validators.minLength(2),Validators.maxLength(40)]],
      start: [null,Validators.required]
    })
  }

  onSubmit() {
    if (this.form.valid) {
      console.log('Form submitted with data:', this.form);
      this.matchService.createMatch(this.form.value).subscribe(
        (response) => {
          console.log(response)
      },
      (error) => {
        alert(error)
      })
    }
    else{
      console.log('Invalid form')
    }
  }
}
