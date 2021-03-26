import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {CompanyServiceService} from '../company-service.service'
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  companies: any = [];
  addCompanyForm !: FormGroup;
  constructor(private httpClient: HttpClient, private companyServiceService : CompanyServiceService) { }

  ngOnInit(): void {
   
    this.httpClient.get("http://localhost:3000/company").subscribe(data =>{
      console.log(data);
      this.companies = data;  
    })
  }

  loadCompanyToEdit(id : number)
  {
    this.companyServiceService.getById(id).subscribe(company => {
      this.addCompanyForm.controls['name'].setValue(company.name);
      this.addCompanyForm.controls['email'].setValue(company.email);
      this.addCompanyForm.controls['address'].setValue(company.address);
      this.addCompanyForm.controls['totalEmployees'].setValue(company.totalEmployees);
      this.addCompanyForm.controls['totalBranch'].setValue(company.totalBranch);
      this.addCompanyForm.controls['isActive'].setValue(company.isActive);
      this.addCompanyForm.controls['isActive'].setValue(company.name);
      this.addCompanyForm.controls['isActive'].setValue(company.name);

    })
  }

  deleteCompany(id : number)
  {
    debugger;
    
      this.companyServiceService.delete(id).subscribe(res => {
        setTimeout("location.reload(true);", 100);
        console.log(res);
      });
    
  }

}
