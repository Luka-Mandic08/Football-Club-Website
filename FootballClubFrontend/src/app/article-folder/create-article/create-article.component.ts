import { Component } from '@angular/core';

import Swal from 'sweetalert2';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CreateArticleDto, Section } from '../../model/article';
import { MatchPreview } from '../../model/match';
import { ArticleService } from '../../services/article-service.service';
import { MatchService } from '../../services/match-service.service';
import { PlayerDto } from 'src/app/model/player';
import { PlayerForSquad } from 'src/app/model/players-for-squad';
import { PlayerService } from 'src/app/services/player-service.service';


@Component({
  selector: 'app-create-article',
  templateUrl: './create-article.component.html',
  styleUrls: ['./create-article.component.css']
})
export class CreateArticleComponent {

  article !: CreateArticleDto
  form : FormGroup
  matches : MatchPreview[] = []
  players : PlayerForSquad[] = []

  selectedPlayers : string[] = []
  paragraphs : Section[] = []
  paragraphText : string = ''

  constructor(private fb:FormBuilder,public articleService:ArticleService,public matchService:MatchService, public playerService: PlayerService){
    this.article = new CreateArticleDto()
    this.form = this.fb.group({
      title: ['',[Validators.required,Validators.minLength(5),Validators.maxLength(100)]],
      uploadDate: [null,[Validators.required,this.validateDate]],
      articleType: [0,[Validators.required]],
      matchId: [' '],
    })

    this.form.valueChanges.subscribe((formValues) => {
      this.article = { ...this.article, ...formValues };
    });
  }

  validateDate(control:AbstractControl){
    if (new Date(control.value) < new Date()) {
      return { 'pastDate': { value: control.value } };
    }
    return null;
  }

  formatDate(d:Date){
    let date = new Date(d)
    return date.getDate() + '.' + (date.getMonth()+1) + '.' + date.getFullYear() + '.'
  }

  ngOnInit(){
    this.matchService.getForNewArticle().subscribe(
      response => {
        this.matches = response
      }
    )
    this.playerService.getAll().subscribe(
      response => this.players = response
    )
  }

  onSelectionChange(event:Event){
    this.selectedPlayers = Array.from((event.target as HTMLSelectElement).selectedOptions).map(option => option.value);
  }

  selectImage(event:any){
    let newParagraph = new Section() 
    const fileName = event.target.value.split('\\')[2];
    if(fileName.split('.')[1]=='mp4'){
      newParagraph.content = "assets/Videos/" + fileName;
      newParagraph.sectionType = 4
    }
    else
    {
      newParagraph.content = "assets/Images/Articles/" + fileName;
      newParagraph.sectionType = 3
    }
    this.paragraphs.push(newParagraph)
    event.target.value = ''
  }

  addParagraph(type:number){
    let paragraph = new Section()
    paragraph.content = this.paragraphText
    paragraph.sectionType = type
    this.paragraphs.push(paragraph)
    this.paragraphText = ''
  }

  removeParagraph(selectedParagraph:Section){
    this.paragraphs.forEach((p,index) => {
      if(selectedParagraph==p){
        this.paragraphs.splice(index,1)
      }
    });
  }

  onSubmit(){
    this.article.paragraphs = this.paragraphs
    this.article.playerIds = this.selectedPlayers
    this.articleService.createArticle(this.article).subscribe(
      (response) => {
        Swal.fire({
          icon: 'success',
          title: 'Success',
          text: response.message,
          showConfirmButton: false,
          position: 'bottom-right',
          timer: 3000,
          timerProgressBar: true,
          backdrop: 'none',
          width: 300,
          background: 'rgb(45,45,148)',
          color: 'white',
        });
      },
      (error) => {
        Swal.fire({
          icon: 'error',
          title: 'Error',
          text: error.error.message,
          showConfirmButton: false,
          position: 'bottom-right',
          timer: 3000,
          timerProgressBar: true,
          backdrop: 'none',
          width: 300,
          background: 'rgb(45,45,148)',
          color: 'white',
        });
      })
  }
}
