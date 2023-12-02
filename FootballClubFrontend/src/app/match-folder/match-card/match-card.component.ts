import { Component, Input } from '@angular/core';
import { MatchPreview } from '../../model/match';

@Component({
  selector: 'app-match-card',
  templateUrl: './match-card.component.html',
  styleUrls: ['./match-card.component.css']
})
export class MatchCardComponent {

  @Input() match !: MatchPreview; 
  formatedDate !: string;
  formatedDateForUrl !: string;
  formatedOpponentName !:string;

  ngOnInit(){
    this.formatedDate = this.formatDate(this.match.start)
    this.formatedDateForUrl = this.formatDateForUrl(this.match.start)
    this.formatedOpponentName = this.formatTeamName(this.match.opponent)
  }

  formatDate(date:Date): string{
    date = new Date(date)
    let formatedDate = '';
    formatedDate += this.getDayOfWeek(date.getDay()) + ' ' + date.getDate() + '/' + date.getMonth() + '/' + date.getFullYear()
    formatedDate += ' ' + date.getHours() + ':' + date.getMinutes() + (date.getMinutes()===0?'0':'')
    return formatedDate
  }

  getDayOfWeek(i:number): string{
    switch(i){
      case 0: return 'Sunday'
      case 1: return 'Monday'
      case 2: return 'Tuesday'
      case 3: return 'Wednesday'
      case 4: return 'Thursday'
      case 5: return 'Friday'
      case 6: return 'Saturday'
      default: return ''
    }
  }

  formatDateForUrl(date:Date): string{
    date = new Date(date)
    let formated = '';
    formated += date.getDate() + '-' + (date.getMonth()+1) + '-' + date.getFullYear()
    return formated
  }

  formatTeamName(name:string):string{
    return name.replace(' ','-').toLowerCase()
  }
}
