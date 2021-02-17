import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuizCreeCodeComponent } from './quiz-cree-code.component';

describe('QuizCreeCodeComponent', () => {
  let component: QuizCreeCodeComponent;
  let fixture: ComponentFixture<QuizCreeCodeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuizCreeCodeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QuizCreeCodeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
