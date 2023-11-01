export class MatchPreview {
  id: string = '';
  opponent: string = '';
  venue: string = '';
  referee: string = '';
  competition: string = '';
  start!: Date;
  goals!: Number;
  opponentGoals!: Number;
  matchEvents: MatchEvent[] = []; 
}

export class MatchEvent {
  minute: string = ''
  text: string = ''
}
