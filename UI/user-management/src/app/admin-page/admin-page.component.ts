import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataServiceService } from '../data-service.service';
import { User } from '../user.model';
import { Country } from '../country.model';
import { UserCountries } from '../userCountries.model';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.scss']
})
export class AdminPageComponent {

  constructor(private dataServiceService: DataServiceService, private router: Router, private route: ActivatedRoute){
  }

  public userGuid: string | null = null;
  public user: User = new User();
  public userFields: User = new User();
  public countryFields: Country = new Country();
  public allCountries: Country[] = [];
  public allUsers: User[] = [];
  public userCountriesLink: UserCountries = new UserCountries();
  
  //User
  addUser(){
    this.dataServiceService.postUser(this.userFields).subscribe(user => { console.log("post: " +user); });
  }
  editUser(){
    this.dataServiceService.putUser(this.userFields).subscribe(user => { console.log("put: " +user); });
  }
  deleteUser(){
    this.dataServiceService.deleteUser(this.userFields.id).subscribe(user => { console.log("delete: " +user); });
  }
  fillUserFields(userSelected :User){
    console.log(userSelected);
    this.userFields = userSelected;
  }
  linkUserCountry(){
    console.log(this.userCountriesLink.userId + " " + this.userCountriesLink.countryId);
    this.userCountriesLink.userId = this.userFields.id;
    this.userCountriesLink.countryId = this.countryFields.id;
    this.dataServiceService.linkUserCountry(this.userCountriesLink).subscribe(userCountries => { console.log("link: " +userCountries);});
  }
  
  //Country
  addCountry(){
    this.dataServiceService.postCountry(this.countryFields).subscribe(country => { console.log("post: "+country); });
  }
  editCountry(){
    this.dataServiceService.putCountry(this.countryFields).subscribe(country => { console.log("put: "+country); });
  }
  deleteCountry(){
    this.dataServiceService.deleteCountry(this.countryFields.id).subscribe(country => { console.log("delete: " +country); });
  }
  fillCountryFields(countrySelected :Country){
    console.log(countrySelected);
    this.countryFields = countrySelected;
  }


  ngOnInit(){
    this.userGuid = localStorage.getItem('guid');
    if(this.userGuid!=null){
      this.dataServiceService.getUserById(this.userGuid).subscribe((user: User) =>{
        console.log("--- AdminPage User ---");
        this.user = user;
      });
      this.dataServiceService.getUsers().subscribe(users =>{
        this.allUsers = users;
      });
      this.dataServiceService.getCountries().subscribe(countries =>{
        this.allCountries = countries;
      });
    }
  }
}
