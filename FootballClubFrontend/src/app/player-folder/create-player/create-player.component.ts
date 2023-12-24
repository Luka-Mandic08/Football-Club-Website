import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, AbstractControl } from '@angular/forms';
import { PlayerService } from '../../services/player-service.service';
import { CreatePlayerDto } from '../../model/player';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-create-player',
  templateUrl: './create-player.component.html',
  styleUrls: ['./create-player.component.css']
})
export class CreatePlayerComponent {
  form : FormGroup;
  player : CreatePlayerDto

  constructor(private fb: FormBuilder,private playerService:PlayerService) {
    this.player = new CreatePlayerDto()
    this.form = this.fb.group({
      name: ['',[Validators.required,Validators.minLength(2),Validators.maxLength(40)]],
      surname: ['',[Validators.required,Validators.minLength(2),Validators.maxLength(40)]],
      dateOfBirth: [null,[Validators.required,this.validateDate]],
      placeOfBirth: ['',[Validators.required,Validators.minLength(2),Validators.maxLength(40)]],
      number: ['',[Validators.required]],
      position: ['',[Validators.required]],
      image: [null,[Validators.required,this.validateImageType]],
    })

    this.form.valueChanges.subscribe((formValues) => {
      this.player = { ...this.player, ...formValues };
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

  validateDate(control:AbstractControl){
    if (new Date(control.value) > new Date()) {
      return { 'futureDate': { value: control.value } };
    }
    return null;
  }

  onSubmit() {
    if (this.form.valid) {
      this.playerService.createPlayer(this.player).subscribe(
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
