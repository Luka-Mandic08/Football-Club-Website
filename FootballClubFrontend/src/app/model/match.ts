export class MatchPreview {
  id: string = '';
  opponent: string = '';
  venue: string = '';
  referee: string = '';
  competition: string = '';
  start!: Date;
  goals!: number;
  opponentGoals!: number;
  season: number=0;
  badge: string = ''
}

export class MatchEvent {
  minute: string = ''
  text: string = ''
}

export class CreateMatch {
  opponent: string = '';
  venue: string = '';
  referee: string = '';
  competition: string = '';
  start!: Date;
  badge: string = ''
}


