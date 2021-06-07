import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CompanyService } from '../shared/services/company.service'
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  companies: any = [];
  addCompanyForm !: FormGroup;
  constructor(private httpClient: HttpClient, private router: Router, private companyService: CompanyService) { }

  ngOnInit(): void {
    this.getCompaniesData();
  }

  getCompaniesData() {
    this.httpClient.get("http://localhost:3000/company").subscribe(data => {
      console.log(data);
      this.companies = data;
    })
  }

  loadCompanyToEdit(id: number) {
    this.companyService.getById(id).subscribe(company => {
      this.companyService.companyDetails(company);
      this.router.navigate(['/edit-company']);
    })
  }

  deleteCompany(id: number) {
    if (!confirm("Are you sure want to delete this record?")) {
      return;
    }
    this.companyService.delete(id).subscribe(res => {
      this.getCompaniesData();
    });

  }

}
