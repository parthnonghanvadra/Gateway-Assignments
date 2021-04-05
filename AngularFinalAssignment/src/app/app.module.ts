import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddCompanyComponent } from './add-company/add-company.component';
import { DashboardComponent } from './dashboard/dashboard.component';

import { NgxSpinnerModule } from "ngx-spinner";
import { EditCompanyComponent } from './edit-company/edit-company.component'; 

@NgModule({
  declarations: [
    AppComponent,
    AddCompanyComponent,
    DashboardComponent,
    EditCompanyComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgxSpinnerModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
