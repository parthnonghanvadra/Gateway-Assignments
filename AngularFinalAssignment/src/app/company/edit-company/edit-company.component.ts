import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Company } from '../../shared/model/company.model';
import { CompanyService } from '../../shared/services/company.service'

@Component({
  selector: 'app-edit-company',
  templateUrl: './edit-company.component.html',
  styleUrls: ['./edit-company.component.css']
})
export class EditCompanyComponent implements OnInit {

  submitted = false;

  editCompanyForm !: FormGroup;
  company !: Company;


  constructor(private formBuilder: FormBuilder, private router: Router, private companyService: CompanyService) { }

  ngOnInit(): void {
    this.editCompanyForm = this.formBuilder.group({
      id: ['', [Validators.required]],
      name: ['', [Validators.required, Validators.minLength(8)]],
      email: ['', [Validators.required, Validators.email, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
      address: ['', Validators.required],
      totalEmployees: ['', Validators.required],
      totalBranch: ['', Validators.required],
      isActive: ['', Validators.required],
      branch: this.formBuilder.array([])
    });

    this.company = this.companyService.getCompany();

    for (const index in this.company.branch) {
      this.addBranch();
    }
    this.editCompanyForm.setValue(this.company)
  }

  get registerFormControl() {
    return this.editCompanyForm.controls;
  }

  get branchs() {
    return this.editCompanyForm.get('branch') as FormArray;
  }

  onCreate(): FormGroup {
    return this.formBuilder.group({
      id: Math.floor(Math.random() * 10) + (new Date()).getTime(),
      name: ['', Validators.required],
<<<<<<< HEAD
      address: ['', Validators.required],
=======
      address: ['', Validators.required]
>>>>>>> fe8c57533fbba001229aae2178f6dda6fab232a5
    })
  }

  onSubmit() {
    this.submitted = true;
    if (this.editCompanyForm.invalid) {
      return;
    }

    this.companyService.update(this.editCompanyForm.value).subscribe(
      res => {
        this.router.navigate(['/dashboard']);
        this.editCompanyForm.reset();
      }
    );
  }

  addBranch() {
    this.branchs.push(this.onCreate())
  }

  deleteBranch(index: number) {
    this.branchs.removeAt(index);
  }

}
