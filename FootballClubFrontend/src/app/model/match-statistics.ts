export class MatchStatisticsDto{
     statistics !: MatchStatistics
     opponentStatistics !: MatchStatistics
}

export class MatchStatistics
{
     generalMatchStatistics !: GeneralMatchStatistics
     attackingMatchStatistics !: AttackingMatchStatistics 
     passingMatchStatistics !: PassingMatchStatistics 
     defendingMatchStatistics !: DefendingMatchStatistics 
}

export class GeneralMatchStatistics
{
     possession : number = 0
     duelSuccessRate : number = 0
     aerialDuelSuccessRate : number = 0
     interceptions : number = 0
     offsides : number = 0
     corners : number = 0
     passes : number = 0
}

export class AttackingMatchStatistics
{
     goals : number = 0
     shots : number = 0
     shotsOnTarget : number = 0
     blockedShots : number = 0
     shotsOutsideTheBox : number = 0
     shotsInsideTheBox : number = 0
     shootingAccuracy : number = 0
}

export class PassingMatchStatistics
{
     longPasses : number = 0
     passingAccuracy : number = 0
     passingAccuracyInOpponentsHalf : number = 0
     crosses : number = 0
     crossingAccuracy : number = 0
}

export class DefendingMatchStatistics
{
     tackles : number = 0
     tackleSuccessRate : number = 0
     clearances : number = 0
     yellowCards : number = 0
     redCards : number = 0
     fouls : number = 0
}