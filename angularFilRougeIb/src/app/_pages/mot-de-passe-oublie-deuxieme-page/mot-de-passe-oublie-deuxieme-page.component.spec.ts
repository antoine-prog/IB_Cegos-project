import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MotDePasseOublieDeuxiemePageComponent } from './mot-de-passe-oublie-deuxieme-page.component';

describe('MotDePasseOublieDeuxiemePageComponent', () => {
  let component: MotDePasseOublieDeuxiemePageComponent;
  let fixture: ComponentFixture<MotDePasseOublieDeuxiemePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MotDePasseOublieDeuxiemePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MotDePasseOublieDeuxiemePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
