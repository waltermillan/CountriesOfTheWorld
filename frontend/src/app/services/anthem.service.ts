import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { Anthem } from '../models/anthem.model';
import { GLOBAL } from '../configuration/configuration.global';


@Injectable({
  providedIn: 'root'
})
export class AnthemService {

 endpoint: string = 'anthems';

  constructor(private http: HttpClient) { }

  getAll():Observable <Anthem[]>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}`
    return this.http.get<Anthem[]>(url);
  }

  getById(id?:number):Observable <Anthem>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}/${id}`
    return this.http.get<Anthem>(url);
  }

  add(anthem:Anthem):Observable <any>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}`
    return this.http.post<any>(url, anthem);
  }

  update(anthem:Anthem):Observable <any>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}/${anthem.id}`
    return this.http.put<any>(url, anthem);
  }

  delete(id:number):Observable <any>{
    const url = `${GLOBAL.apiBaseUrl}${this.endpoint}/${id}`
    return this.http.delete<any>(url);
  }
}
