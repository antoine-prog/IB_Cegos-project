import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeConnecteComponent } from './home-connecte.component';

describe('HomeConnecteComponent', () => {
  let component: HomeConnecteComponent;
  let fixture: ComponentFixture<HomeConnecteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomeConnecteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeConnecteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
