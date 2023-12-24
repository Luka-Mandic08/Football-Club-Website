import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TablesEditComponent } from './tables-edit.component';

describe('TablesEditComponent', () => {
  let component: TablesEditComponent;
  let fixture: ComponentFixture<TablesEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TablesEditComponent]
    });
    fixture = TestBed.createComponent(TablesEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
