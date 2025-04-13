import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { Continent } from '../models/continent.model';
import { GLOBAL } from '../configuration/configuration.global';


@Injectable({
  providedIn: 'root'
})
export class ContinentService {

  endpoint: string = 'continents';

  constructor(private http: HttpClient) { }

  getAll():Observable <Continent[]>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}`
    return this.http.get<Continent[]>(url);
  }

  getById(id?:number):Observable <Continent>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}/${id}`
    return this.http.get<Continent>(url);
  }

  add(continent:Continent):Observable <any>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}`
    return this.http.post<any>(url, continent);
  }

  update(continent:Continent):Observable <any>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}/${continent.id}`
    return this.http.put<any>(url, continent);
  }

  delete(id:number):Observable <any>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}/${id}`
    return this.http.delete<any>(url);
  }
}
