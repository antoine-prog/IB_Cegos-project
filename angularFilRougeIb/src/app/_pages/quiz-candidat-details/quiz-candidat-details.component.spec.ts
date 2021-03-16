import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuizCandidatDetailsComponent } from './quiz-candidat-details.component';

describe('QuizCandidatDetailsComponent', () => {
  let component: QuizCandidatDetailsComponent;
  let fixture: ComponentFixture<QuizCandidatDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuizCandidatDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QuizCandidatDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
