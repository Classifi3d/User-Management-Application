import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { UserPageComponent } from './user-page/user-page.component';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CountryCardComponent } from './country-card/country-card.component';
import { FormsModule } from '@angular/forms';
import { PipeInitialsPipe } from './pipe-initials.pipe';
import { PipeTypeidPipe } from './pipe-typeid.pipe';
import { DropdownCountryComponent } from './dropdown-country/dropdown-country.component';
import { DropdownUserComponent } from './dropdown-user/dropdown-user.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    UserPageComponent,
    AdminPageComponent,
    NavbarComponent,
    CountryCardComponent,
    PipeInitialsPipe,
    PipeTypeidPipe,
    DropdownCountryComponent,
    DropdownUserComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [HttpClientModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
