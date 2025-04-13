export class Country {
    id: number;
    name: string;
    spanishName: string;
    population: number;
    surface: number;
    independenceDay: Date;
    govermentId: number;
    languageId: number;
    continentId: number;
    anthemId: number;

    constructor() {
      this.id = 0;
      this.name = '';
      this.spanishName = '';
      this.population  = 0;
      this.surface = 0;
      this.independenceDay= new Date();
      this.govermentId = 0;
      this.languageId = 0;
      this.continentId = 0;
      this.anthemId = 0;
    }
  }
  