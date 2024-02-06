import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router';
import { JWT_OPTIONS, JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})

export class AuthGuardService implements CanActivate{

  constructor(private router: Router,private jwtHelper: JwtHelperService) {}

  canActivate(route: ActivatedRouteSnapshot): boolean {
    let token_string = localStorage.getItem('jwt')
    if (token_string!='' && token_string!=null) {
      const requiredRole = route.data['roles'] as string;
      if (localStorage.getItem('role')==requiredRole && !this.jwtHelper.isTokenExpired(token_string)) {
        return true;
      } else {
        alert('Unauthorized route')
        this.router.navigate(['']);
        return false;
      }
    } else {
      this.router.navigate(['']);
      return false;
    }
  }

  isAdmin(): boolean {
    let token = localStorage.getItem('jwt')
    if (token!='' && token!=null) {
      if (localStorage.getItem('role')=='Admin' && !this.jwtHelper.isTokenExpired(token)) {
        return true;
      } else {
        return false;
      }
    } else {
      return false;
    }
  }

  isLoggedIn(): boolean{
    let token = localStorage.getItem('jwt')
    if(token!='' && token!=null){
      return !this.jwtHelper.isTokenExpired(token)
    }
    return false
  }
}
