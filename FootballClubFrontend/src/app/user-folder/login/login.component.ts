import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { LoginDto } from 'src/app/model/user';
import { UserService } from 'src/app/services/user-service.service';
import { JWT_OPTIONS, JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  form: FormGroup;
  loginDto: LoginDto;

  constructor(
    private fb: FormBuilder,
    public userService: UserService,
    private dialogRef: MatDialogRef<LoginComponent>,
    private router: Router,
    private jwtHelper: JwtHelperService
  ) {
    this.loginDto = new LoginDto();
    this.form = this.fb.group({
      email: [this.loginDto.email, [Validators.required]],
      password: [this.loginDto.password, [Validators.required]],
    });

    this.form.valueChanges.subscribe((formValues) => {
      this.loginDto = { ...this.loginDto, ...formValues };
    });
  }

  onSubmit() {
    if (this.form.valid) {
      this.userService.login(this.loginDto).subscribe( response => 
        {
            localStorage.setItem('jwt', response.token);
            var token = this.jwtHelper.decodeToken(response.token)
            localStorage.setItem('user', token.unique_name)
            localStorage.setItem('role',token.role)
            this.dialogRef.close(true);
        },
        error => {
          if(error.error.message === 'Bad credentials')
            alert(error.error.message)
          else
            alert('Something went wrong')
        });
    }
  }

  goToRegister() {
    this.dialogRef.close(false);
    this.router.navigateByUrl('register');
  }
}
