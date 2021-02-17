import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditQCMComponent } from './edit-qcm.component';

describe('EditQCMComponent', () => {
  let component: EditQCMComponent;
  let fixture: ComponentFixture<EditQCMComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditQCMComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditQCMComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
