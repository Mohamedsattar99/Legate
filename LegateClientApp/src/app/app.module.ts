import { BrowserModule } from '@angular/platform-browser';
import { NgModule,Pipe } from '@angular/core';
import {RouterModule} from '@angular/router';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import{ HomeComponent} from '../app/home/home.component';
import{NotFoundComponent } from '../app/error-pages/not-found/not-found.component';
import{ MenuComponent} from '../app/menu/menu.component';
import { InternalServerComponent } from './error-pages/internal-server/internal-server.component';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NotFoundComponent,
    MenuComponent,
    InternalServerComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    
    RouterModule.forRoot([
      {path:'home', component:HomeComponent},
      {path:'404', component:NotFoundComponent},
      {path:'500',component:InternalServerComponent},
      {path:'user',loadChildren :() =>import('./user/user.module').then(m=>m.UserModule)},
      {path:'',redirectTo:'/home',pathMatch:'full'},
      {path:'**',redirectTo:'/404', pathMatch:'full'},
    ])
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
