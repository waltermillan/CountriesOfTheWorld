import { Component, Input, OnChanges, OnInit } from '@angular/core';

import { Symbol } from '../models/symbol.model';
import { SymbolService } from '../services/symbol.service';

@Component({
  selector: 'app-show-info-coat-of-arms',
  templateUrl: './show-info-coat-of-arms.component.html',
  styleUrl: './show-info-coat-of-arms.component.css'
})
export class ShowInfoCoatOfArmsComponent implements OnInit, OnChanges {

  @Input() countryId?: number;
  symbolInfo?:Symbol;

  constructor(private symbolService:SymbolService) {
    
  }

  ngOnInit(): void {
    this.getSymbolInfo();
  }

  ngOnChanges(): void {
    this.getSymbolInfo();
  }

  getSymbolInfo() {
    this.symbolService.getById(this.countryId).subscribe({
      next: (data) => {
          this.symbolInfo = data;
      },
      error: (error) => {
        console.error('Error loading symbol: ', error);
      }
    });
  }
}
