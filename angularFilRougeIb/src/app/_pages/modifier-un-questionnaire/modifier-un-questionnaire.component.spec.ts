import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModifierUnQuestionnaireComponent } from './modifier-un-questionnaire.component';

describe('ModifierUnQuestionnaireComponent', () => {
  let component: ModifierUnQuestionnaireComponent;
  let fixture: ComponentFixture<ModifierUnQuestionnaireComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModifierUnQuestionnaireComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModifierUnQuestionnaireComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
