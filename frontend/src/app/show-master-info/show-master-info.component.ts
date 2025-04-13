import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import { Country } from '../models/country.model';
import { CountryService } from '../services/country.service';
import { GLOBAL } from '../configuration/configuration.global';

import { InformationDialogComponent } from '../modals/information-dialog/information-dialog.component';


@Component({
  selector: 'show-master-info-country',
  templateUrl: './show-master-info.component.html',
  styleUrl: './show-master-info.component.css'
})
export class ShowMasterInfoComponent implements OnInit {
  countries: any[] = [];
  selectedIdountry: number = 0;

  showMessage: boolean = false;
  message: string = '';
  countryInfo?: Country;

  appName: string = GLOBAL.appLegalName.replace('__YEAR__', GLOBAL.currentYear.toString());
  appVersion = GLOBAL.appVersion;

  constructor(private dialog: MatDialog,
              private countryService: CountryService) {
    this.showMessage = false;
  }

  ngOnInit() {
    this.getAllCountries();

    this.dialog.open(InformationDialogComponent, {
      data: {
        message: 'Please select a country from the list.'
      }
    });
  }

  getAllCountries(): void {
    this.countryService.getAll().subscribe({
      next: (data) => {
        this.countries = data.sort((a, b) => a.name.localeCompare(b.name));
      },
      error: (error) => {
        console.error('Error loading countries: ', error);
        this.showMessage = true;
        this.message = 'Error connected to the API.';
      }
    });
  }

  getCountryInfo(id: number) {
    this.countryService.getById(id).subscribe({
      next: (data) => {
        this.countryInfo = data;
        //this.loadMapByCountry(data.name);  // Cargamos el mapa al obtener la info
      },
      error: (error) => {
        console.error('Error getting data country.', error);
        this.dialog.open(InformationDialogComponent, {
          data: {
            message: 'Error getting data country.'
          }
        });
      }
    });
  }

  onCountrySelect() {
    this.getCountryInfo(this.selectedIdountry);
  }

  refresh() {
    window.location.reload();
  }
}
