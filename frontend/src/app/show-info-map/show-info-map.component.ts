import { Component, Input, OnChanges } from '@angular/core';
import maplibregl from 'maplibre-gl';
import { Country } from '../models/country.model';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-show-info-map',
  templateUrl: './show-info-map.component.html',
  styleUrl: './show-info-map.component.css'
})
export class ShowInfoMapComponent implements OnChanges {

  @Input() countryInfo?: Country;
  map: maplibregl.Map | undefined; // Variable to maintain the map

  constructor(private http: HttpClient) {
    
  }

  ngOnChanges() {
    if (this.countryInfo) {
      this.loadMapByCountry(this.countryInfo.name);  // call the map when changing the selection
    }
  }

  loadMapByCountry(countryName: string) {
    // If a map already exists, delete it before creating a new one.
    if (this.map) {
      this.map.remove();
    }

    const url = `https://nominatim.openstreetmap.org/search?country=${countryName}&format=json&limit=1`;

    this.http.get<any[]>(url).subscribe(data => {
      if (data.length > 0) {
        const lat = parseFloat(data[0].lat);
        const lon = parseFloat(data[0].lon);
        this.initMap(lat, lon);
      } else {
        console.error('País no encontrado');
      }
    });
  }

  initMap(lat: number, lon: number) {
    // New map
    this.map = new maplibregl.Map({
      container: 'map', // Container where the map is rendered
      style: 'https://demotiles.maplibre.org/style.json',
      center: [lon, lat],
      zoom: 4
    });
  }
}
