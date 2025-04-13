import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialogModule } from '@angular/material/dialog';
import { InformationDialogComponent } from './information-dialog.component';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

describe('InformationDialogComponent', () => {
  let component: InformationDialogComponent;
  let fixture: ComponentFixture<InformationDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MatDialogModule],
      declarations: [InformationDialogComponent],
      providers: [
        { provide: MAT_DIALOG_DATA, useValue: { message: 'Hello World' } }  // Asegúrate de proporcionar MAT_DIALOG_DATA
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(InformationDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
