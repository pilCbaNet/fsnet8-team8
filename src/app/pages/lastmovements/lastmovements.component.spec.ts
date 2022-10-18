import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LastmovementsComponent } from './lastmovements.component';

describe('LastmovementsComponent', () => {
  let component: LastmovementsComponent;
  let fixture: ComponentFixture<LastmovementsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LastmovementsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LastmovementsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
