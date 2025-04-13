import { Component, OnInit, OnChanges, SimpleChanges, Input } from '@angular/core';

import { Country } from '../models/country.model';
import { Goverment } from '../models/goverment.model';
import { GovermentService } from '../services/goverment.service';
import { Language } from '../models/language.model';
import { LanguageService } from '../services/language.service';
import { Continent } from '../models/continent.model';
import { ContinentService } from '../services/continent.service';


@Component({
  selector: 'app-show-info-country',
  templateUrl: './show-info-country.component.html',
  styleUrl: './show-info-country.component.css'
})
export class ShowInfoCountryComponent implements OnInit, OnChanges {

  @Input() countryInfo?: Country;

  symbolInfo?:Symbol;
  govermentInfo?:Goverment;
  languageInfo?:Language;
  continentInfo?:Continent;

  constructor(private govermentService: GovermentService,
    private languageService: LanguageService,
    private continentService: ContinentService) {
    
  }

  ngOnInit(): void {
    this.getGovermentInfo();
    this.getLanguageInfo();
    this.getContinentInfo();
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.getGovermentInfo();
    this.getLanguageInfo();
    this.getContinentInfo();
  }

  getGovermentInfo():void{
    this.govermentService.getById(this.countryInfo?.govermentId).subscribe({
      next: (data) => {
        this.govermentInfo = data;
      },
      error: (error) => {
        console.error('Error loading goverment: ', error);
      }
    });
  }

  getLanguageInfo():void {
    this.languageService.getById(this.countryInfo?.languageId).subscribe({
      next: (data) => {
        this.languageInfo = data;
      },
      error: (error) => {
        console.error('Error loading language: ', error);
      }
    });
  }

  getContinentInfo():void {
    this.continentService.getById(this.countryInfo?.continentId).subscribe({
      next: (data) => {
        this.continentInfo = data;
      },
      error: (error) => {
        console.error('Error loading continent: ', error);
      }
    });
  }
}
