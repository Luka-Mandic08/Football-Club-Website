import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterDto } from 'src/app/model/user';
import { AuthGuardService } from 'src/app/services/auth-guard.service';
import { UserService } from 'src/app/services/user-service.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  
  form: FormGroup
  registerDto : RegisterDto
  isAdmin : boolean

  constructor(private fb:FormBuilder,public userService:UserService,private auth:AuthGuardService,private router:Router){
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

    this.isAdmin = this.auth.isAdmin()
    if(this.auth.isLoggedIn() && !this.isAdmin)
      this.router.navigateByUrl('')
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
          this.router.navigateByUrl('')
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
  }

  registerAdmin(){
    if(this.form.valid){
      this.userService.registerAdmin(this.registerDto).subscribe(
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
  }
}
