export class LoginDto {
    email : string = ''
    password : string = ''
}

export class RegisterDto {
    email : string = '';
    password : string = ''
    name : string = ''
    surname : string = ''
    dateOfBirth !: Date
    country : string = ''
    gender : string = ''
    
}