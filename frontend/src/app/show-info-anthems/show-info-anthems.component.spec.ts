import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowInfoAnthemsComponent } from './show-info-anthems.component';

describe('ShowInfoAnthemsComponent', () => {
  let component: ShowInfoAnthemsComponent;
  let fixture: ComponentFixture<ShowInfoAnthemsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShowInfoAnthemsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowInfoAnthemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
