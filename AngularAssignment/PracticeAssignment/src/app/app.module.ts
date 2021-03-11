import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { FormsModule } from '@angular/forms';
import { DemoComponentComponent } from './demo-component/demo-component.component';
import { RoutingComponentComponent } from './routing-component/routing-component.component';

@NgModule({
  declarations: [
    AppComponent,
    DemoComponentComponent,
    RoutingComponentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
