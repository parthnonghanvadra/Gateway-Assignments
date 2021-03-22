import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MyserviceService {

  constructor() { }

  showTodayDate() {
    const date = new Date();
    return date;

}}
