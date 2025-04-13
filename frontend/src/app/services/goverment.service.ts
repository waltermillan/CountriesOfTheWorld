import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { Goverment } from '../models/goverment.model';
import { GLOBAL } from '../configuration/configuration.global';

@Injectable({
  providedIn: 'root'
})
export class GovermentService {

    endpoint: string = 'goverments';
  
    constructor(private http: HttpClient) { }
  
    getAll():Observable <Goverment[]>{
      const url = `${GLOBAL.apiBaseUrl}${this.endpoint}`
      return this.http.get<Goverment[]>(url);
    }
  
    getById(id?:number):Observable <Goverment>{
      const url = `${GLOBAL.apiBaseUrl}${this.endpoint}/${id}`
      return this.http.get<Goverment>(url);
    }
  
    add(goverment:Goverment):Observable <any>{
      const url = `${GLOBAL.apiBaseUrl}${this.endpoint}`
      return this.http.post<any>(url, goverment);
    }
  
    update(goverment:Goverment):Observable <any>{
      const url = `${GLOBAL.apiBaseUrl}${this.endpoint}/${goverment.id}`
      return this.http.put<any>(url, goverment);
    }
  
    delete(id:number):Observable <any>{
      const url = `${GLOBAL.apiBaseUrl}${this.endpoint}/${id}`
      return this.http.delete<any>(url);
    }
}
