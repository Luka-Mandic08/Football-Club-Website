import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Article } from 'src/app/model/article';
import { ArticleService } from 'src/app/services/article-service.service';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent {

  article !: Article
  id : string = ''

  constructor(private router: Router, private route: ActivatedRoute, public articleService : ArticleService) {
    const state = this.router.getCurrentNavigation()?.extras.state as {
      id: string,
    };
    if(state?.id)
      this.id = state.id
  }

  ngOnInit(){
    if(this.id!==''){
        this.articleService.getById(this.id).subscribe(
          response => this.article = response
      )
    }
    else{
      this.article = new Article()
      this.article.title = "This article is unavailable"
    }
  }

  formatDate(date:Date): string{
    let formatedDate = date.getDate() + '.' + date.getMonth() + '.' + date.getFullYear() + '.'
    return formatedDate
  }

}
