import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCompanyComponent } from './add-company/add-company.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EditCompanyComponent } from './edit-company/edit-company.component';

const routes: Routes = [
  {
    path: '',    
    redirectTo: 'dashboard',    
    pathMatch: 'full',    
  },
  {
    path : 'dashboard',
    component : DashboardComponent
  },
  {
    path : 'add-company',
    component : AddCompanyComponent
  },
  {
    path : 'edit-company',
    component : EditCompanyComponent
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
