import { Component } from '@angular/core';
import { IncrementDecrementService } from './services/increment-decrement.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Assignment6';
  constructor(public incrementDecrement: IncrementDecrementService){}

  increment() {
    this.incrementDecrement.increment();
  }
  
}