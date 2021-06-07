import { DebugElement } from '@angular/core';
import {
  ComponentFixture,
  fakeAsync,
  TestBed,
  tick,
} from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { IncrementDecrementService } from './services/increment-decrement.service';

describe('AppComponent', () => {
  let fixture: ComponentFixture<AppComponent>;
  let debugElement: DebugElement;
  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [AppComponent],
      providers: [IncrementDecrementService],
    }).compileComponents();
    fixture = TestBed.createComponent(AppComponent);
    debugElement = fixture.debugElement;
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'Assignment6'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('Assignment6');
  });

  it('should increment in template after 5 seconds', fakeAsync(() => {
    debugElement
      .query(By.css('button.increment'))
      .triggerEventHandler('click', null);
    tick(2000);
    fixture.detectChanges();
    let value = debugElement.query(By.css('h1')).nativeElement.innerText;
    expect(value).toEqual('0'); // value should still be 0 after 2 seconds

    tick(3000);
    fixture.detectChanges();

    value = debugElement.query(By.css('h1')).nativeElement.innerText;
    expect(value).toEqual('1'); // 3 seconds later, our value should now be 1
  }));
});