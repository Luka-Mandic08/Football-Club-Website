import { Component } from '@angular/core';
import { ArticleService } from '../services/article-service.service';
import { Article } from '../model/article';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  featuredArticle !: Article
  featuredArticlePhoto !: string | ArrayBuffer | null | undefined
  articles : Article[] = []
  featuredArticleHeader !: string | ArrayBuffer | null | undefined

  constructor(public articleService: ArticleService,private router: Router){}

  ngOnInit(){
    this.articleService.getForHomePage().subscribe(
      response => {
        this.featuredArticle = response[0]
        this.featuredArticlePhoto = response[0].paragraphs.find(element=>element.sectionType==3)?.content
        this.featuredArticleHeader = response[0].paragraphs.find(element=>element.sectionType==0)?.content
        this.articles = response.slice(1)
      }
    )
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
