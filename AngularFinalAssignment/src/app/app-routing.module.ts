import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCompanyComponent } from './company/add-company/add-company.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EditCompanyComponent } from './company/edit-company/edit-company.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full',
  },
  {
    path: 'dashboard',
    component: DashboardComponent
  },
  {
    path: 'add-company',
    component: AddCompanyComponent
  },
  {
    path: 'edit-company',
    component: EditCompanyComponent
  },
  {
    path: '**',
    redirectTo: 'dashboard'
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
