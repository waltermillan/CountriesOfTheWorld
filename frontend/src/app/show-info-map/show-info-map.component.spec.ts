import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowInfoMapComponent } from './show-info-map.component';

describe('ShowInfoMapComponent', () => {
  let component: ShowInfoMapComponent;
  let fixture: ComponentFixture<ShowInfoMapComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShowInfoMapComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowInfoMapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
