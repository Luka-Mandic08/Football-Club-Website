import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MatchStatisticsEditComponent } from './match-statistics-edit.component';

describe('MatchStatisticsEditComponent', () => {
  let component: MatchStatisticsEditComponent;
  let fixture: ComponentFixture<MatchStatisticsEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MatchStatisticsEditComponent]
    });
    fixture = TestBed.createComponent(MatchStatisticsEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
