import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {DemoComponentComponent} from './demo-component/demo-component.component'
import {RoutingComponentComponent} from './routing-component/routing-component.component'
import {AppComponent} from './app.component'

const routes: Routes = [ 
  {
    path: "routing",
    component:RoutingComponentComponent
  },
  {
    path: "demo",
    component:DemoComponentComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
