import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, AbstractControl } from '@angular/forms';
import { PlayerService } from '../services/player-service.service';
import { CreatePlayerDto } from '../model/player';

@Component({
  selector: 'app-create-player',
  templateUrl: './create-player.component.html',
  styleUrls: ['./create-player.component.css']
})
export class CreatePlayerComponent {
  form : FormGroup;

  constructor(private fb: FormBuilder,private playerService:PlayerService) {
    this.form = this.fb.group({
      name: ['',[Validators.required,Validators.minLength(2),Validators.maxLength(40)]],
      surname: ['',[Validators.required,Validators.minLength(2),Validators.maxLength(40)]],
      dateOfBirth: [null,[Validators.required,this.validateDate]],
      placeOfBirth: ['',[Validators.required,Validators.minLength(2),Validators.maxLength(40)]],
      number: ['',[Validators.required]],
      position: ['',[Validators.required]],
      image: [null,[Validators.required,this.validateImageType]],
    })
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

  validateDate(control:AbstractControl){
    if (new Date(control.value) > new Date()) {
      return { 'futureDate': { value: control.value } };
    }
    return null;
  }

  onSubmit() {
    if (this.form.valid) {
      let dto = this.createDto()
      this.playerService.createPlayer(dto).subscribe(
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

  createDto():CreatePlayerDto{
    const dto : CreatePlayerDto = {
      name: this.form.value.name,
      surname: this.form.value.surname,
      dateOfBirth: this.form.value.dateOfBirth,
      placeOfBirth: this.form.value.placeOfBirth,
      position: this.form.value.position,
      squadNumber: this.form.value.number,
      image: this.form.value.image
    }
    return dto
  }
}