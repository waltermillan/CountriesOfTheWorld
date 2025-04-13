import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowInfoFlagComponent } from './show-info-flag.component';

describe('ShowInfoFlagComponent', () => {
  let component: ShowInfoFlagComponent;
  let fixture: ComponentFixture<ShowInfoFlagComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShowInfoFlagComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowInfoFlagComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
