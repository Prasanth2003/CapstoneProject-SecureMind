import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginpageComponent } from './Components/loginpage/loginpage.component';
import { RegisterpageComponent } from './Components/registerpage/registerpage.component';
import { PagenotfoundComponent } from './Components/pagenotfound/pagenotfound.component';
import { HomepageComponent } from './Components/homepage/homepage.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginpageComponent,
    RegisterpageComponent,
    PagenotfoundComponent,
    HomepageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }