import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot([
      // { path: '', redirectTo: 'app', pathMatch: 'full' },
      { path: 'app', component: AppComponent }
       
    ])
  ],
  providers: [
    
  
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
