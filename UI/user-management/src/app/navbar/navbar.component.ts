import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataServiceService } from '../data-service.service';
import { PipeInitialsPipe } from '../pipe-initials.pipe';
import { User } from '../user.model';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})



export class NavbarComponent{
  constructor(private dataServiceService: DataServiceService, private router: Router, private route: ActivatedRoute){

  }

  username = '';
  public userGuid: string | null = null;
  public user: User = new User();
  public backgroundColor: string = '#82868b';
   // darkMode = false;
   
  public toAdmin(){
    console.log(this.user);
    if(this.user.type_id==2){
      this.router.navigate(['/admin']);
    }
  }

  public logout(){
    // delete token
    localStorage.removeItem('guid');
    this.router.navigate(['/login']);
  }

  ngOnInit(){
    // console.log("Navbar: "+localStorage.getItem('guid'));
    this.userGuid = localStorage.getItem('guid');
    if(this.userGuid!=null){
      this.dataServiceService.getUserById(this.userGuid).subscribe((user: User) =>{
        console.log("--- Navbar User ---");
        this.user = user;
        this.username = user.first_Name + ' ' + user.last_Name;
        console.log(this.username);

      });
    }

    // Random User Icon Background Color
    this.backgroundColor = '#'+Math.floor(Math.random()*16777215).toString(16);
    
  }

  // DARK THEME (WIP)
  // toggleLight(event: any): void {
  // this.darkMode =!this.darkMode;
  // console.log(event);
  // }
  
}
