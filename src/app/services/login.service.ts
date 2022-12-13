import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Login } from '../models/login';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http:HttpClient) 
  {
    console.log("el servicio login funciona");
   }

   iniciarSesion(login: Login):Observable<any>
   {

    return this.http.post('http://localhost:3000/posts', login)
   }



   encontrarUsuario() : Observable<any>
   {
    return this.http.get('http://localhost:3000/users');
   }
}
