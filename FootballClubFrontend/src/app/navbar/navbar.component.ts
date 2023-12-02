import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from '../user-folder/login/login.component';
import { JwtHelperService, JWT_OPTIONS  } from '@auth0/angular-jwt';

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
  userIsLoggedIn !: boolean 
  constructor(private dialog: MatDialog, private jwtHelper:JwtHelperService) {
    let token = localStorage.getItem('jwt')
    if(token!=null){
      let decodedToken = this.jwtHelper.decodeToken(token)
      console.log(decodedToken)
      this.userIsLoggedIn = true
    }
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
    })
  }


}
