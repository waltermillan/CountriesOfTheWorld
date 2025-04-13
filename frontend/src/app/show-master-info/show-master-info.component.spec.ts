import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowMasterInfoComponent } from './show-master-info.component';

describe('ShowMasterInfoComponent', () => {
  let component: ShowMasterInfoComponent;
  let fixture: ComponentFixture<ShowMasterInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShowMasterInfoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowMasterInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
