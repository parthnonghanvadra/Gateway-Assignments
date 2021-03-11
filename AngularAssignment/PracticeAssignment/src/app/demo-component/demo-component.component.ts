import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-demo-component',
  templateUrl: './demo-component.component.html',
  styleUrls: ['./demo-component.component.css']
})
export class DemoComponentComponent implements OnInit {


  @Input() childInputString !:string;  
  @Output() myOutput:EventEmitter<string>= new EventEmitter();  
  childOutPutString = "Child Component String"
  constructor() { }

  ngOnInit(): void {
  }
  
    sendData(){  
       this.myOutput.emit(this.childOutPutString);  
    }  

    
}
