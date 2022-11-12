import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AboutUsService {

  constructor(private http:HttpClient) {
    console.log("El servicio anda")
   }
   obtenerDatosAboutUs():Observable<any>
   {
    return this.http.get('http://localhost:3000/team');
   }
}
