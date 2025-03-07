import { Component, Input, OnInit, ViewChild, ElementRef  } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Country } from '../models/country.model';
import { Goverment } from '../models/goverment.model';
import { Language } from '../models/language.model';
import { Continent } from '../models/continent.model';
import { Anthem } from '../models/anthem.model';

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
})
export class InfoComponent implements OnInit {
  countries: any[] = [];
  selectedCountry: string = '';
  countryInfo?:Country;
  govermentInfo?:Goverment;
  languageInfo?:Language;
  continentInfo?:Continent;
  anthemInfo?:Anthem;

  @ViewChild('flagname') flagImage: ElementRef<HTMLImageElement> | undefined;

  constructor(private http: HttpClient) {}

  getFlagImage(countryCode:number) {
        if (this.flagImage) {
      this.flagImage.nativeElement.src = `assets/images/flags/${countryCode}.jpg`;
    }
  }

  getMapImage(countryCode:number): string {
    return `assets/images/maps/${countryCode}.jpg`; 
  }

  ngOnInit() {
    this.getAllCountries();
  }

  ngOnChanges() {

  }

  getCountryInfo(countryCode:any) {
    
    const url = `http://localhost:5184/api/countries/${countryCode}`;
    this.http.get<any>(url).subscribe((data) => {
      this.countryInfo = data;
      this.getGovermentInfo(); 
      this.getLanguageInfo();
      this.getContinentInfo();
      this.getAnthemInfo();
    });
  }

  getGovermentInfo():void{
    const url = `http://localhost:5184/api/goverments/${this.countryInfo?.govermentId}`;
    console.log('url: ' + url);
    this.http.get<any>(url).subscribe((data) => {
      this.govermentInfo = data;
    });
  }

  getLanguageInfo():void {
    const url = `http://localhost:5184/api/languages/${this.countryInfo?.languageId}`;
    console.log('url: ' + url);
    this.http.get<any>(url).subscribe((data) => {
      this.languageInfo = data;
    });
  }

  getContinentInfo():void {
    const url = `http://localhost:5184/api/continents/${this.countryInfo?.continentId}`;
    console.log('url: ' + url);
    this.http.get<any>(url).subscribe((data) => {
      this.continentInfo = data;
    });
  }

  getAnthemInfo():void {
    const url = `http://localhost:5184/api/anthems/${this.countryInfo?.anthemId}`;
    console.log('url: ' + url);
    this.http.get<any>(url).subscribe((data) => {
      this.anthemInfo = data;
      console.log('X: ' + this.anthemInfo?.content)
    });
  }

  playAnthem() {
    if (this.anthemInfo?.content) {
      const audio = new Audio(this.anthemInfo?.content);
      audio.play();
    }
  }

  getAllCountries():void{
    this.http.get<any>('http://localhost:5184/api/countries/').subscribe((data: any) => {
    this.countries = data.sort((a: any, b: any) => a.spanishName.localeCompare(b.spanishName));
    });
  }

  onCountrySelect() {
    console.log(this.selectedCountry);
    this.getCountryInfo(this.selectedCountry);
  }
}
