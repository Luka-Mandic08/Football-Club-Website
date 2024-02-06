import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Article } from 'src/app/model/article';

@Component({
  selector: 'app-article-card-vertical',
  templateUrl: './article-card-vertical.component.html',
  styleUrls: ['./article-card-vertical.component.css']
})
export class ArticleCardVerticalComponent {
  
  @Input() article !: Article
  firstPicture : string | ArrayBuffer | null = ''

  constructor(private router:Router){}

  ngOnInit(){
    this.article.paragraphs.forEach(p => {
      if(this.firstPicture==='' && p.sectionType===3)
        this.firstPicture = p.content
    });
  }

  formatDate(d:Date){
    let date = new Date(d)
    return date.getDate() + '.' + (date.getMonth()+1) + '.' + date.getFullYear() + '.'
  }

  formatTitle(title:string) :string{
    return title.toLowerCase().replace(' ','-')
  }

  route(article : Article){
    const navigationExtras = {
      state: {
        id: article.id,
      },
    };
    this.router.navigate(['article/' + this.formatTitle(article.title)],navigationExtras)
  }
}
