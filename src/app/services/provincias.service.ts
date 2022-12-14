import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Provincia } from '../models/provincia';
import { Localidad } from '../models/localidad';

@Injectable({
  providedIn: 'root'
})
export class ProvinciasService {
  urlProvincias: string="https://localhost:7155/api/Provincias";
  urlLocalidades: string="https://localhost:7155/api/Localidades/";




  constructor(private http:HttpClient) { 
    
  }

  getProvinciasList():Observable<any[]>{
    return this.http.get<any>(this.urlProvincias);
  }


  getLocalidadesList(IdProvincia: number){
    return this.http.get<any>(this.urlLocalidades+IdProvincia);
  }

}
