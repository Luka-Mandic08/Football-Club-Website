export class PlayerStatisticsDto {
  statistics !: PlayerStatistics[]
  opponentStatistics !: PlayerStatistics[]
}

export class PlayerStatistics {
  id: string | null  = '';
  matchId: string = '';
  playerId: string | undefined = '';
  playerName: string = '';
  season: number = 0;
  competition: string = '';
  team: string = '';
  generalStatistics!: GeneralStatistics;
  passingStatistics!: PassingStatistics;
  goalkeepingStatistics!: GoalkeepingStatistics | null;
  defendingStatistics!: DefendingStatistics | null;
  attackingStatistics!: AttackingStatistics | null;
}

export class AttackingStatistics {
  totalShots: number = 0;
  totalGoals: number = 0;
  shotsOnTarget: number = 0;
  rightFootedGoals: number = 0;
  leftFootedGoals: number = 0;
  headedGoals: number = 0;
  freekickGoals: number = 0;
  assists: number = 0;
}

export class DefendingStatistics {
  clearances: number = 0;
  blocks: number = 0;
  interceptions: number = 0;
  successfulTackles: number = 0;
  totalTackles: number = 0;
  successfulAerialDuels: number = 0;
  totalAerialDuels: number = 0;
  successfulGroundDuels: number = 0;
  totalGroundDuels: number = 0;
}

export class GoalkeepingStatistics {
  numberOfSaves: number = 0;
  numberOfShotsFaced: number = 0;
  cleanSheets: number = 0;
  penaltiesSaved: number = 0;
  catches: number = 0;
}

export class GeneralStatistics {
  gamesPlayed: number = 0;
  minutesPlayed: number = 0;
  foulsWon: number = 0;
  foulsConceded: number = 0;
  yellowCards: number = 0;
  redCards: number = 0;
}

export class PassingStatistics {
  totalPasses: number = 0;
  completedPasses: number = 0;
  totalLongPasses: number = 0;
  completedLongPasses: number = 0;
  completedCrosses: number = 0;
  secondAssists: number = 0;
  keyPasses: number = 0;
}
