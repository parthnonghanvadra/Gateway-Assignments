import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Company } from './model/company.model';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CompanyServiceService {

  private api = "http://localhost:3000";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private httpClient: HttpClient) { }

  create(comapny : Company) : Observable<Company>
  {
    return this.httpClient.post<Company>(this.api + '/company', JSON.stringify(comapny), this.httpOptions)
  }

  getAllComapnies() : Observable<Company>
  {
    return this.httpClient.get<Company>(this.api + '/company');

  }

  update(comapny : Company, id : number) : Observable<Company>
  {
    return this.httpClient.put<Company>(this.api + '/company/' + id, JSON.stringify(comapny), this.httpOptions);
  }

  delete(id : number){
    debugger
    console.log(this.api + '/company/' + id);
    debugger
    return this.httpClient.delete<Company>(this.api + '/company/' + id, this.httpOptions)
  }

  getById(id : number){
    return this.httpClient.get<Company>(this.api + '/company/' + id, this.httpOptions)
  }

}
