import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MesQuestionnairesComponent } from './mes-questionnaires.component';

describe('MesQuestionnairesComponent', () => {
  let component: MesQuestionnairesComponent;
  let fixture: ComponentFixture<MesQuestionnairesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MesQuestionnairesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MesQuestionnairesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
