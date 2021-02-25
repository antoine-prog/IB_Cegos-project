import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ValidationQuizCandidatComponent } from './validation-quiz-candidat.component';

describe('ValidationQuizCandidatComponent', () => {
  let component: ValidationQuizCandidatComponent;
  let fixture: ComponentFixture<ValidationQuizCandidatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ValidationQuizCandidatComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ValidationQuizCandidatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
