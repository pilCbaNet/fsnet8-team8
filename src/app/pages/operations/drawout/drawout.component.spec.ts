import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DrawoutComponent } from './drawout.component';

describe('DrawoutComponent', () => {
  let component: DrawoutComponent;
  let fixture: ComponentFixture<DrawoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DrawoutComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DrawoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
