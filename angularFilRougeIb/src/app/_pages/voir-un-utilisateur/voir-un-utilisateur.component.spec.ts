import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VoirUnUtilisateurComponent } from './voir-un-utilisateur.component';

describe('VoirUnUtilisateurComponent', () => {
  let component: VoirUnUtilisateurComponent;
  let fixture: ComponentFixture<VoirUnUtilisateurComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VoirUnUtilisateurComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VoirUnUtilisateurComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
