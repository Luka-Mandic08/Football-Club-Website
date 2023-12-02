import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegisterDto } from 'src/app/model/user';
import { UserService } from 'src/app/services/user-service.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  
  form: FormGroup
  registerDto : RegisterDto

  constructor(private fb:FormBuilder,public userService:UserService){
    this.registerDto = new RegisterDto()
    this.form = this.fb.group({
      name: [this.registerDto.name,[Validators.required,Validators.minLength(2),Validators.maxLength(20)]],
      surname: [this.registerDto.surname,[Validators.required,Validators.minLength(2),Validators.maxLength(40)]],
      dateOfBirth: [this.registerDto.dateOfBirth,[Validators.required,this.validateDate]],
      country: [this.registerDto.country,[Validators.required,Validators.minLength(2),Validators.maxLength(40)]],
      gender: [this.registerDto.gender,[Validators.required]],
      email: [this.registerDto.email,[Validators.required,Validators.email]],
      password: [this.registerDto.password,[Validators.required,Validators.minLength(6),Validators.maxLength(40)]],
    })

    this.form.valueChanges.subscribe((formValues) => {
      this.registerDto = { ...this.registerDto, ...formValues };
    });
  }

  validateDate(control:AbstractControl){
    if (new Date(control.value) > new Date()) {
      return { 'futureDate': { value: control.value } };
    }
    return null;
  }

  onSubmit(){
    if(this.form.valid){
      this.userService.registerUser(this.registerDto).subscribe(
        response => console.log(response)
      )
    }
  }
}
