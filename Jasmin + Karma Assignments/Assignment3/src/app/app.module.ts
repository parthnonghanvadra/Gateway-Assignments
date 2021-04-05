import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CalculatorComponent } from './calculator/calculator.component';
import { CounterComponent } from './counter/counter.component';
import { LightswitchComponent } from './lightswitch/lightswitch.component';
import { CheckNumberComponent } from './check-number/check-number.component';

@NgModule({
  declarations: [
    AppComponent,
    CalculatorComponent,
    CounterComponent,
    LightswitchComponent,
    CheckNumberComponent
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
