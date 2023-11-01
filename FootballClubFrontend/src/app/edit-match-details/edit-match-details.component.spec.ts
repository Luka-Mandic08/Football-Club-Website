import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditMatchDetailsComponent } from './edit-match-details.component';

describe('EditMatchDetailsComponent', () => {
  let component: EditMatchDetailsComponent;
  let fixture: ComponentFixture<EditMatchDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditMatchDetailsComponent]
    });
    fixture = TestBed.createComponent(EditMatchDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
