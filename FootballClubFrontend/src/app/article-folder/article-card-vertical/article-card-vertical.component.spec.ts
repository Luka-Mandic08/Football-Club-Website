import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticleCardVerticalComponent } from './article-card-vertical.component';

describe('ArticleCardVerticalComponent', () => {
  let component: ArticleCardVerticalComponent;
  let fixture: ComponentFixture<ArticleCardVerticalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ArticleCardVerticalComponent]
    });
    fixture = TestBed.createComponent(ArticleCardVerticalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
