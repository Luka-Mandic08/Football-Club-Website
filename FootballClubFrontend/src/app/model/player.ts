export class CreatePlayerDto {
  name: string = '';
  surname: string = '';
  dateOfBirth!: Date;
  placeOfBirth: string = '';
  position: Number = 0;
  squadNumber: Number = 0;
  image: string = '';
}
