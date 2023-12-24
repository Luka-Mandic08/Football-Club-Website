export class Table {
    id : string = ''
    competition : string = ''
    season : number = 0
    rows : TableRow[] = []
}

export class TableRow{
    id !: string | null
    team : string = ''
    position : number = 0
    wins : number = 0
    draws : number = 0
    losses : number = 0
    goalDifference : number = 0
    points : number = 0
}

export class CreateTableDto {
    competition : string = ''
    season : number = 0
    rows : TableRow[] = []
}