import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MatchPlayerStatisticsEditComponent } from './match-player-statistics-edit.component';

describe('MatchPlayerStatisticsEditComponent', () => {
  let component: MatchPlayerStatisticsEditComponent;
  let fixture: ComponentFixture<MatchPlayerStatisticsEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MatchPlayerStatisticsEditComponent]
    });
    fixture = TestBed.createComponent(MatchPlayerStatisticsEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
