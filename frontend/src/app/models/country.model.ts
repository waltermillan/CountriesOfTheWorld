export interface Country {
    id: number;
    name: string;
    spanishName: string;
    population: number; // Cambié de string a number
    surface: number;
    independenceDay: Date; // Corregí la ortografía
    govermentId: number;  // Corregí la ortografía
    languageId: number;
    continentId: number;
    anthemId: number;
  }
  