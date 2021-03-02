import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VoletConnectionComponent } from './volet-connection.component';

describe('VoletConnectionComponent', () => {
  let component: VoletConnectionComponent;
  let fixture: ComponentFixture<VoletConnectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VoletConnectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VoletConnectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
