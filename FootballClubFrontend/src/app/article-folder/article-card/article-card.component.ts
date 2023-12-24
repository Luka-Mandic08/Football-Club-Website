import { Component, Input } from '@angular/core';
import { Article } from 'src/app/model/article';

@Component({
  selector: 'app-article-card',
  templateUrl: './article-card.component.html',
  styleUrls: ['./article-card.component.css']
})
export class ArticleCardComponent {

  @Input() article !: Article
  firstPicture : string | ArrayBuffer | null = ''

  constructor(){}

  ngOnInit(){
    this.article.paragraphs.forEach(p => {
      if(this.firstPicture==='' && p.sectionType===3)
        this.firstPicture = p.content
    });
  }
}
