import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreationQuizComponent } from './creation-quiz.component';

describe('CreationQuizComponent', () => {
  let component: CreationQuizComponent;
  let fixture: ComponentFixture<CreationQuizComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreationQuizComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreationQuizComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
