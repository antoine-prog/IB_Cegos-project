import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuizCandidatComponent } from './quiz-candidat.component';

describe('QuizCandidatComponent', () => {
  let component: QuizCandidatComponent;
  let fixture: ComponentFixture<QuizCandidatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuizCandidatComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QuizCandidatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
