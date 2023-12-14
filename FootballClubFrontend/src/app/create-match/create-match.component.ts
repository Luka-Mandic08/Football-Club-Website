import { Component, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatchService} from '../services/match-service.service';
import { CreateMatch, MatchPreview } from '../model/match';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-create-match',
  templateUrl: './create-match.component.html',
  styleUrls: ['./create-match.component.css']
})
export class CreateMatchComponent {
  
  form : FormGroup;
  match : CreateMatch;

  constructor(private fb: FormBuilder,private matchService:MatchService) {
    this.match = new MatchPreview()
    this.form = this.fb.group({
      opponent: ['',[Validators.required,Validators.minLength(2),Validators.maxLength(40)]],
      venue: ['',[Validators.required,Validators.minLength(2),Validators.maxLength(40)]],
      referee: ['',[Validators.required,Validators.minLength(2),Validators.maxLength(40)]],
      competition: ['',[Validators.required,Validators.minLength(2),Validators.maxLength(40)]],
      start: [null,Validators.required],
      badge: [null,[Validators.required,this.validateImageType]],
    })

    this.form.valueChanges.subscribe((formValues) => {
      this.match = { ...this.match, ...formValues };
    });
  }

  validateImageType(control: FormControl) {
    const file = control.value;

    if (!file) {
      return null; // No file selected
    }

    const allowedTypes = ['jpg', 'jpeg', 'png'];
    const fileName = file.toLowerCase();
    const extension = fileName.split('.').pop();

    if (extension && allowedTypes.includes(extension)) {
      return null; // Valid file type
    } else {
      return { invalidFileType: true };
    }
  }

  onSubmit() {
    if (this.form.valid) {
      this.matchService.createMatch(this.match).subscribe(
        (response) => {
          Swal.fire({
            icon: 'success',
            title: 'Success',
            text: response.message,
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
      })
    }
    else{
      console.log('Invalid form')
    }
  }
}
