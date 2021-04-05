import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserLoginComponent } from './user-login.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { UserloginService } from '../services/userlogin.service';
import { User } from '../Entities/User';

describe('Component: Login', () => {

  let component: UserLoginComponent;
  let fixture: ComponentFixture<UserLoginComponent>;
  let service : UserloginService;
  let spy: any;
  beforeEach(() => {

      // refine the test module by declaring the test component
      TestBed.configureTestingModule({
          imports: [ReactiveFormsModule, FormsModule],
          declarations: [UserLoginComponent]
      });

      // create component and test fixture
      fixture = TestBed.createComponent(UserLoginComponent);
      service = new UserloginService();
      // get test component from the fixture
      component = fixture.componentInstance;
      component.ngOnInit();
  });

  it('form invalid when empty', () => {
      expect(component.form.valid).toBeFalsy();
  });

  it('email field validity', () => {
      let errors : any;
      let email = component.form.controls['email'];
      expect(email.valid).toBeFalsy();

      // Email field is required
      errors = email.errors || {};
      expect(errors['required']).toBeTruthy();

      // Set email to something
      email.setValue("test");
      errors = email.errors || {};
      expect(errors['required']).toBeFalsy();
      expect(errors['pattern']).toBeTruthy();

      // Set email to something correct
      email.setValue("test@example.com");
      errors = email.errors || {};
      expect(errors['required']).toBeFalsy();
      expect(errors['pattern']).toBeFalsy();
  });

  it('password field validity', () => {
      let errors : any;
      let password = component.form.controls['password'];

      // Email field is required
      errors = password.errors || {};
      expect(errors['required']).toBeTruthy();

      // Set email to something
      password.setValue("123456");
      errors = password.errors || {};
      expect(errors['required']).toBeFalsy();
      expect(errors['minlength']).toBeTruthy();

      // Set email to something correct
      password.setValue("123456789");
      errors = password.errors || {};
      expect(errors['required']).toBeFalsy();
      expect(errors['minlength']).toBeFalsy();
  });

  it('submitting a form emits a user', () => {
    expect(component.form.valid).toBeFalsy();
    component.form.controls['email'].setValue("test@test.com");
    component.form.controls['password'].setValue("123456789");
    expect(component.form.valid).toBeTruthy();

    let user !: User;
    // Subscribe to the Observable and store the user in a local variable.
    component.loggedIn.subscribe((value) => user = value);

    // Trigger the login function
    component.login();

    // Now we can check to make sure the emitted value is correct
    
    expect(component.login).toBeTruthy()
    expect(service).toBeTruthy();
    expect(service.addUser(new User("test@test.com", "123456789"))).toEqual(true);
    expect(user.email).toBe("test@test.com");
    expect(user.password).toBe("123456789");
  });
}); 
