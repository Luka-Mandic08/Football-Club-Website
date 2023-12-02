import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MatchEventCardComponent } from './match-event-card.component';

describe('MatchEventCardComponent', () => {
  let component: MatchEventCardComponent;
  let fixture: ComponentFixture<MatchEventCardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MatchEventCardComponent]
    });
    fixture = TestBed.createComponent(MatchEventCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
