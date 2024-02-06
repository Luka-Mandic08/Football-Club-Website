import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Article } from 'src/app/model/article';
import { ArticleService } from 'src/app/services/article-service.service';
import { AuthGuardService } from 'src/app/services/auth-guard.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css']
})
export class ArticlesComponent {

  type : number = -1
  title : string = ''
  page : number = 1
  articles : Article[] = []
  isAdmin : boolean
  isMoreContent : boolean = false

  constructor(private route:ActivatedRoute,private router:Router,public articleService:ArticleService,private auth:AuthGuardService){
    this.isAdmin = this.auth.isAdmin()
    this.route.params.subscribe(params => {
      let typeString = this.route.snapshot.paramMap.get('type')
      switch(typeString){
        case 'news': this.type = 0;this.title='Latest news articles';break;
        case 'history': this.type = 1;this.title='History of the club';break;
        case 'information': this.type = 2;this.title='Information';break;
        default: this.router.navigateByUrl('')
      }
      this.articleService.getByType(this.type,this.page).subscribe(
        response => {
          this.articles = response
          if(this.articles.length==10)
            this.isMoreContent = true
        }
      )
    })   
  }

  changePage(nextPage:boolean){
    if(nextPage) // Checks if the change in pages is up or down
      this.page++
    else
      this.page--
    this.articleService.getByType(this.type,this.page).subscribe(
      response => {
        if(response.length>0){
          this.articles = response 
          if(this.articles.length==10) 
            this.isMoreContent = true
          else
            this.isMoreContent = false
        }
        else
          Swal.fire({
            icon: 'warning',
            title: 'No more articles to show',
            showConfirmButton: false,
            position: 'bottom-right',
            timer: 3000,
            timerProgressBar: true,
            backdrop: 'none',
            width: 300,
            background: 'rgb(45,45,148)',
            color: 'white',
          });        
      }
    )
  }

  newArticle(){
    this.router.navigateByUrl('articles/create')
  }
}
