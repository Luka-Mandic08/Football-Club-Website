export class Article {
    id : string = ''
    title : string =''
    paragraphs : Section[] = []
    uploadDate !: Date 
    articleType : number = 0
    matchId !: string
    playerIds : string[] = []
}

export class Section {
    content : string | null | ArrayBuffer = ''
    sectionType : number = 0
}

export class CreateArticleDto {
    title : string =''
    paragraphs : Section[] = []
    uploadDate !: Date 
    articleType : number = 0
    matchId !: string
    playerIds : string[] = []
}