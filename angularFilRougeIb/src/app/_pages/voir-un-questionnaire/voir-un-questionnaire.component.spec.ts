import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VoirUnQuestionnaireComponent } from './voir-un-questionnaire.component';

describe('VoirUnQuestionnaireComponent', () => {
  let component: VoirUnQuestionnaireComponent;
  let fixture: ComponentFixture<VoirUnQuestionnaireComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VoirUnQuestionnaireComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VoirUnQuestionnaireComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
