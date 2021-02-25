import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreationQuestionsQuizComponent } from './creation-questions-quiz.component';

describe('CreationQuestionsQuizComponent', () => {
  let component: CreationQuestionsQuizComponent;
  let fixture: ComponentFixture<CreationQuestionsQuizComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreationQuestionsQuizComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreationQuestionsQuizComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
