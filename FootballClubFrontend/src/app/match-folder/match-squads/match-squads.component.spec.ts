import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MatchSquadsComponent } from './match-squads.component';

describe('MatchSquadsComponent', () => {
  let component: MatchSquadsComponent;
  let fixture: ComponentFixture<MatchSquadsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MatchSquadsComponent]
    });
    fixture = TestBed.createComponent(MatchSquadsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
