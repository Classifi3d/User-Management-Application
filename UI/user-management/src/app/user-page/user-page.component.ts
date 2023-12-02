import { Component, OnInit } from '@angular/core';
import { DataServiceService } from '../data-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../user.model';
import { __assign } from 'tslib';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.scss']
})
export class UserPageComponent implements OnInit {
  public userGuid: string | null = null;
  public user: User = new User();

  constructor(private dataServiceService: DataServiceService, private router: Router, private route: ActivatedRoute){
  }

  ngOnInit() {
    this.userGuid = localStorage.getItem('guid');
    if(this.userGuid!=null){
      this.dataServiceService.getUserById(this.userGuid).subscribe(user =>{
        console.log("--- UserPage User ---");
        this.user = user;
      });

    }
  }

}
