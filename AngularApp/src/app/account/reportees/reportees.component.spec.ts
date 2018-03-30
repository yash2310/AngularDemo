import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReporteesComponent } from './reportees.component';

describe('ReporteesComponent', () => {
  let component: ReporteesComponent;
  let fixture: ComponentFixture<ReporteesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReporteesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReporteesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
