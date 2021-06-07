import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { Router } from '@angular/router';
import { Company } from '../../shared/model/company.model';
import { CompanyService } from '../../shared/services/company.service'

@Component({
  selector: 'app-add-company',
  templateUrl: './add-company.component.html',
  styleUrls: ['./add-company.component.css']
})
export class AddCompanyComponent implements OnInit {

  submitted = false;

  addCompanyForm !: FormGroup;
  company !: Company[];

  constructor(private formBuilder: FormBuilder, private router: Router, private companyService: CompanyService) { }

  ngOnInit(): void {
    this.addCompanyForm = this.formBuilder.group({
      id: [Math.floor(Math.random() * 10) + (new Date()).getTime()],
      name: ['', [Validators.required, Validators.minLength(8)]],
      email: ['', [Validators.required, Validators.email, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
      address: ['', Validators.required],
      totalEmployees: ['', Validators.required],
      totalBranch: ['', Validators.required],
      isActive: ['', Validators.required],
      branch: this.formBuilder.array([this.formBuilder.group({ id: Math.floor(Math.random() * 10) + (new Date()).getTime(), name: '', address: '' })])
    });
  }

  get registerFormControl() {
    return this.addCompanyForm.controls;
  }

  get branchs() {
    return this.addCompanyForm.get('branch') as FormArray;
  }

  onSubmit() {
    this.submitted = true;
    if (this.addCompanyForm.invalid) {
      return;
    }
    this.companyService.create(this.addCompanyForm.value).subscribe(
      res => {
        this.router.navigate(['/dashboard']);
        this.addCompanyForm.reset();
      }
    );
  }

  addBranch() {
    this.branchs.push(this.formBuilder.group({ id: '', name: '', address: '' }))
  }

  deleteBranch(index: number) {
    this.branchs.removeAt(index);
  }

}
