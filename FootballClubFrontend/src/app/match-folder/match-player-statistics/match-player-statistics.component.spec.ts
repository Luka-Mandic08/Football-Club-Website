import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MatchPlayerStatisticsComponent } from './match-player-statistics.component';

describe('MatchPlayerStatisticsComponent', () => {
  let component: MatchPlayerStatisticsComponent;
  let fixture: ComponentFixture<MatchPlayerStatisticsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MatchPlayerStatisticsComponent]
    });
    fixture = TestBed.createComponent(MatchPlayerStatisticsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
