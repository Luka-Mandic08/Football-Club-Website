import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from '../user-folder/login/login.component';
import { JwtHelperService, JWT_OPTIONS  } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { AuthGuardService } from '../services/auth-guard.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
  providers: [
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },
    JwtHelperService
]
})
export class NavbarComponent {
  
  selectedTab : string = 'matches'
  userIsLoggedIn : boolean 
  isAdmin : boolean

  constructor(private dialog: MatDialog, private auth:AuthGuardService,private router:Router) {
    this.userIsLoggedIn = this.auth.isLoggedIn()
    this.isAdmin = this.auth.isAdmin()
  }

  selectTab(newTab:string){
    this.selectedTab = newTab;
  }

  loginPopup(){
    const dialogRef = this.dialog.open(LoginComponent, {
      width: '350px',
      height: '400px',
      autoFocus: false,
      closeOnNavigation:true,
      enterAnimationDuration: 0.2,
      exitAnimationDuration: 0.2,
    });

    dialogRef.afterClosed().subscribe((result:Boolean) => {
      if(result)
        this.userIsLoggedIn = true
        this.isAdmin = this.auth.isAdmin()
    })
  }

  logOut(){
    localStorage.clear()
    this.userIsLoggedIn = false
    this.isAdmin = false
    this.router.navigateByUrl('')
  }
}
