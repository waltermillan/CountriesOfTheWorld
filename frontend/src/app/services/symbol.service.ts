import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { Symbol } from '../models/symbol.model';
import { GLOBAL } from '../configuration/configuration.global';

@Injectable({
  providedIn: 'root'
})
export class SymbolService {

  endpoint: string = 'symbols';

  constructor(private http: HttpClient) { }

  getAll():Observable <Symbol[]>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}`
    return this.http.get<Symbol[]>(url);
  }

  getById(id?:number):Observable <Symbol>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}/${id}`
    return this.http.get<Symbol>(url);
  }

  add(symbol:Symbol):Observable <any>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}`
    return this.http.post<any>(url, symbol);
  }

  update(symbol:Symbol):Observable <any>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}/${symbol.id}`
    return this.http.put<any>(url, symbol);
  }

  delete(id:number):Observable <any>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}/${id}`
    return this.http.delete<any>(url);
  }
}
