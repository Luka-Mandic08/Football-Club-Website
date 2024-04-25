import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MatchCardVerticalComponent } from './match-card-vertical.component';

describe('MatchCardVerticalComponent', () => {
  let component: MatchCardVerticalComponent;
  let fixture: ComponentFixture<MatchCardVerticalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MatchCardVerticalComponent]
    });
    fixture = TestBed.createComponent(MatchCardVerticalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
