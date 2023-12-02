import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from './user.model';
import {Country} from './country.model';
import { Observable, map, pipe } from 'rxjs';
import { UserCountries } from './userCountries.model';

@Injectable({
  providedIn: 'root'
})
export class DataServiceService {

  private url: string;
  private headers: HttpHeaders;
  private logedInHeader: HttpHeaders;
  private paramsUser: HttpParams;

  constructor(private http: HttpClient) { 
    this.headers = new HttpHeaders();
    this.logedInHeader = new HttpHeaders();

    this.headers.append('Access-Control-Allow-Headers', 'Content-Type');
    this.headers.append('Content-Type', 'application/json');
    this.headers.append('Access-Control-Allow-Origin', '*');

    this.logedInHeader.append('Access-Control-Allow-Headers', 'Content-Type');
    this.logedInHeader.append('Content-Type', 'application/json');
    this.logedInHeader.append('Access-Control-Allow-Origin', '*');
    this.logedInHeader.append('Authorization',`Bearer ${localStorage.getItem('token')}`);
   
    this.url = 'https://localhost:7035/api';

    this.paramsUser = new HttpParams({});
  }

//User Requests
  // ALL USERS
  public getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.url}/User`, 
    {
      headers: this.headers,
      observe:'response',
    }).pipe(map(response => response.body as User[]));
  }
  // USER by ID
  public getUserById(id: string): Observable<User> {
    return this.http.get<User>(`${this.url}/User/${id}`, 
    {
      headers: this.headers,
      observe:'response',
      // headers: this.headers,
    }).pipe(map(response => response.body as User));
  }
  // ADD USER
  public postUser(user: User): Observable<void>{
    const  userBody = {
      id : user.id,
      email : user.email,
      password : user.password,
      first_name : user.first_Name,
      last_name : user.last_Name,
      type_id : user.type_id
    };
    return this.http.post<void>(`${this.url}/User`,
    userBody,
    {
      headers: this.headers,
    });
  }

  // UPDATE USER
  public putUser(user: User): Observable<User> {
    const  userBody = {
      id : user.id,
      email : user.email,
      password : user.password,
      first_name : user.first_Name,
      last_name : user.last_Name,
      type_id : user.type_id
    };
    return this.http.put<User>(`${this.url}/User`,
    userBody,
    {
      headers: this.headers,
    });
  }

  // DELETE USER
  public deleteUser(id: string): Observable<boolean>{
    return this.http.delete<boolean>(`${this.url}/User/${id}`,
    {
      headers: this.headers,
      observe:'response',
    }).pipe(map(response => response.body as boolean));
  }
  // LOGIN 
  public loginUser(user: User): Observable<string>{
    const  userBody = {
      email : user.email,
      password : user.password,
    };
    return this.http.post<string>(`${this.url}/User/loginold`,
    userBody,
    {
      headers: this.headers,
    }).pipe(map((response) => {
      return response as string;
    }));
  }
  // LINK USER-COUNTRY
  public linkUserCountry(userCountries: UserCountries): Observable<string>{
    const  userCountriesBody = {
      userId : userCountries.userId,
      countryId : userCountries.countryId,
    };
    return this.http.post<string>(`${this.url}/User/CountryLink`,
    userCountriesBody,
    {
      headers: this.headers,
    }).pipe(map((response) => {
      return response as string;
    }));
  }

//Country Requests 

  // ALL COUNTRIES 
  public getCountries(): Observable<Country[]> {
    return this.http.get<Country[]>(`${this.url}/Countries`,
    {
      headers: this.headers,
      observe: 'response',
  }).pipe(map(response => response.body as Country[]));
  }
  // COUNTRY by ID
  public getCountrtyById(id: string): Observable<Country> {
    return this.http.get<Country>(`${this.url}/Countries/${id} `,
    {
      headers: this.headers,
      observe: 'response',
  }).pipe(map(response => response.body as Country));
  }
  // ADD COUNTRY
  public postCountry(country: Country): Observable<Country> {
    const countryBody = {
      id : country.id,
      name : country.name,
      code : country.code,
      flag : country.flag
    };
    return this.http.post<Country>(`${this.url}/Countries`,
    countryBody,
    {
      headers: this.headers,
    });
  }
  // UPDATE COUNTRY
  public putCountry(country: Country): Observable<Country> {
    const countryBody = {
      id : country.id,
      name : country.name,
      code : country.code,
      flag : country.flag
    };
    return this.http.put<Country>(`${this.url}/Countries`,
    countryBody,
    {
      headers: this.headers,
    });
  }
  // DELETE COUNTRY
  public deleteCountry(id: string): Observable<boolean>{
    return this.http.delete<boolean>(`${this.url}/Countries/${id}`,
    {
      headers: this.headers,
      observe:'response',
    }).pipe(map(response => response.body as boolean));
  }

}
