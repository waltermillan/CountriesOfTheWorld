import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowInfoCoatOfArmsComponent } from './show-info-coat-of-arms.component';

describe('ShowInfoCoatOfArmsComponent', () => {
  let component: ShowInfoCoatOfArmsComponent;
  let fixture: ComponentFixture<ShowInfoCoatOfArmsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShowInfoCoatOfArmsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowInfoCoatOfArmsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
