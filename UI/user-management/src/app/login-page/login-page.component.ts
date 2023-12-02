import { Component, OnInit } from '@angular/core';
import { DataServiceService } from '../data-service.service';
import { User } from '../user.model';
import { ActivatedRoute, Router } from '@angular/router';
import { Country } from '../country.model';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  public countryExample1 = {
    name: 'United States',
    code: 'US',
    flag: 'USflagflag',
  } as Country;
  public countryExample2 = {
    name: 'Germany',
    code: 'DU',
    flag: 'Duflagflag',
  } as Country;
  public countryList = [this.countryExample1, this.countryExample2];
  public countries: Country[] = []
  public country: Country = new Country();

  public users: User[] = [];
  // public user: User = new User();
  public userExample = {
    email: 'user@example.com',
    password: 'password2',
    first_Name: 'FIRST',
    last_Name: 'NAME',
    type_id: 0,
    countries: this.countryList
  } as User;

  public loginUser = {
    email: '',
    password: '',
  } as User;
  public user: User = new User();
  public email: string = '';
  public password: string = '';
  public loginResponse: string = '';
  constructor(private dataServiceService: DataServiceService, private router: Router, private route: ActivatedRoute) {
  }
  ngOnInit(): void {
    // === ENDPOINT TESTS ===

    // --- USER ---
    // this.dataServiceService.getUsers().subscribe(users =>{
    //   this.users = users;
    //   console.log("users: "+users)
    // });
    // this.dataServiceService.getUserById("dac40ba3-bec4-4ada-e626-08dbcb239b6f").subscribe(user => {
    //   this.user = user;
    //   console.log("userbyid: "+user);
    // });
    // this.dataServiceService.postUser(this.userExample).subscribe(user => { console.log("post: " +user); });
    // this.dataServiceService.putUser(this.userExample).subscribe(user => { console.log("put: " +user); });
    // this.dataServiceService.deleteUser("ce1a3b7c-1a53-48df-2333-08dbccc97c32").subscribe();
    // this.dataServiceService.loginUser(this.userExample).subscribe(booleanish => { console.log("login: "+booleanish); });

    // --- COUNTRIES ---
    // this.dataServiceService.getCountries().subscribe(countries => { 
    //   this.countries = countries;
    //   console.log("countries: "+countries);
    // });
    // this.dataServiceService.getCountrtyById("3f229ec6-b8b4-4176-328c-08dbc458e910").subscribe(country => { 
    //   this.country = country;
    //   console.log("countrybyid: "+country);
    // });
    // this.dataServiceService.postCountry(this.countryExample1).subscribe(country => { console.log("post: "+country); });
    // this.dataServiceService.putCountry(this.countryExample1).subscribe(country => { console.log("put: "+country); });
    // this.dataServiceService.deleteCountry("3f229ec6-b8b4-4176-328c-08dbc458e910").subscribe();

  }


  public onLogin(): void {
    // console.log(this.email);
    // console.log(this.password);
    this.loginUser.email = this.email;
    this.loginUser.password = this.password;
    console.log(this.loginUser);


    this.dataServiceService.loginUser(this.loginUser).subscribe(loginResponse => {
      this.loginResponse = loginResponse;
      console.log("Login Status: "+loginResponse);
      localStorage.setItem('guid',this.loginResponse);
      this.router.navigate(['/user']);
    });

  }
}
