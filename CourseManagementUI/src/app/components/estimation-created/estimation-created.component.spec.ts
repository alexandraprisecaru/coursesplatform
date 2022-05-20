import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EstimationCreatedComponent } from './estimation-created.component';

describe('EstimationCreatedComponent', () => {
  let component: EstimationCreatedComponent;
  let fixture: ComponentFixture<EstimationCreatedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EstimationCreatedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EstimationCreatedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
