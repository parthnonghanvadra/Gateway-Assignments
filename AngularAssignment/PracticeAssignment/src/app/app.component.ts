import { Component } from '@angular/core';
import { MyserviceService } from './myservice.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'PracticeAssignment';
  name = "Parth Nonghanvadra";
  birthDate = new Date(2000, 7, 4);
  todaydate !: Date;

  inputString = "Parent Component String"
  constructor(private myservice: MyserviceService) {}

  ngOnInit() {
    this.todaydate = this.myservice.showTodayDate();
 }

  isUnchanged = true;
  size = 0;

  onChange(){
    this.title = "After Clicked!"
  }

  dec(){
    this.size--;
  }
  inc(){
    this.size++;
  }

  GetChildData(data : string){
      console.log(data)
    }
}
