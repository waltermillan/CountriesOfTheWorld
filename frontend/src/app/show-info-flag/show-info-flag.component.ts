import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';

import { Symbol } from '../models/symbol.model';
import { SymbolService } from '../services/symbol.service';

@Component({
  selector: 'app-show-info-flag',
  templateUrl: './show-info-flag.component.html',
  styleUrl: './show-info-flag.component.css'
})
export class ShowInfoFlagComponent implements OnInit, OnChanges {

  @Input() countryId?:number;
  symbolInfo?: Symbol;


  constructor(private symbolService: SymbolService) {

  }

  ngOnInit(): void {
    this.getSymbolInfo();
  }

  ngOnChanges(changes: SimpleChanges): void {
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
