import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { Language } from '../models/language.model';
import { GLOBAL } from '../configuration/configuration.global';

@Injectable({
  providedIn: 'root'
})
export class LanguageService {

  endpoint: string = 'languages';

  constructor(private http: HttpClient) { }

  getAll():Observable <Language[]>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}`
    return this.http.get<Language[]>(url);
  }

  getById(id?:number):Observable <Language>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}/${id}`
    return this.http.get<Language>(url);
  }

  add(language:Language):Observable <any>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}`
    return this.http.post<any>(url, language);
  }

  update(language:Language):Observable <any>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}/${language.id}`
    return this.http.put<any>(url, language);
  }

  delete(id:number):Observable <any>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}/${id}`
    return this.http.delete<any>(url);
  }
}
