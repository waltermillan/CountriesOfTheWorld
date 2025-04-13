import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { Country } from '../models/country.model';
import { GLOBAL } from '../configuration/configuration.global';

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  endpoint: string = 'countries';

  constructor(private http: HttpClient) { }

  getAll():Observable <Country[]>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}`
    return this.http.get<Country[]>(url);
  }

  getById(id?:number):Observable <Country>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}/${id}`
    return this.http.get<Country>(url);
  }

  add(country:Country):Observable <any>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}`
    return this.http.post<any>(url, country);
  }

  update(country:Country):Observable <any>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}/${country.id}`
    return this.http.put<any>(url, country);
  }

  delete(id:number):Observable <any>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}/${id}`
    return this.http.delete<any>(url);
  }
}
