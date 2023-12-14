export class CreatePlayerDto {
  name: string = '';
  surname: string = '';
  dateOfBirth!: Date;
  placeOfBirth: string = '';
  position: Number = 0;
  squadNumber: Number = 0;
  image: string = '';
}

export class PlayerDto {
  id: string = ''
  name: string = '';
  surname: string = '';
  dateOfBirth!: Date;
  placeOfBirth: string = '';
  position: Number = 0;
  squadNumber: Number = 0;
  image: string = '';
  dateJoined!: Date;
  status: Number = 0;
}

export class GetStatisticsForPlayerDto {
  id: string|null = ''
  name: string = '';
  competition: string = '';
  season: Number = 0;

  constructor(id:string|null,name:string,competition:string,season:number){
    this.id = id
    this.name = name
    this.competition = competition
    this.season = season
  }
}

export class AllPlayersDto {
  activePlayers : PlayerDto[] = []
  loanedPlayers : PlayerDto[] = []
}
