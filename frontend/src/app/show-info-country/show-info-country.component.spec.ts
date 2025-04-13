import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowInfoCountryComponent } from './show-info-country.component';

describe('ShowInfoCountryComponent', () => {
  let component: ShowInfoCountryComponent;
  let fixture: ComponentFixture<ShowInfoCountryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShowInfoCountryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowInfoCountryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
