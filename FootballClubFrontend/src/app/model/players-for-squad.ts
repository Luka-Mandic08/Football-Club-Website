export class PlayerForSquad {
    id: string|undefined = ''
    name : string = ''
    surname : string = ''
    squadNumber : number = 0
}

export class Squads {
    squad : PlayerForSquad[] = []
    opponentSquad : PlayerForSquad[] = []
    eligiblePlayers : PlayerForSquad[] = []
    subs : PlayerForSquad[] = []
    opponentSubs : PlayerForSquad[] = []
}