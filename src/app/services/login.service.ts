import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { Login } from '../models/login';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  urlLogin: string="https://localhost:7155/api/Usuarios/login";
  urlRegister: string="https://localhost:7155/api/Usuarios";

  loggedIn= new BehaviorSubject<boolean>(false);
  currentUserSubject: BehaviorSubject<Login>;
  currentUser: Observable<Login>;

  constructor(private http:HttpClient, private router: Router) 
  {
    this.currentUserSubject = new BehaviorSubject<Login>(JSON.parse(localStorage.getItem('currentUser') || '{}'));
    this.currentUser = this.currentUserSubject.asObservable();
   }

   iniciarSesion(login: Login):Observable<any>
   {

    return this.http.post<any>(this.urlLogin, login); 
    // .pipe(map(data =>{
    //   sessionStorage.setItem
    // }))
   }


registrarUsuario(user: User):Observable<any>{



  return this.http.post<any>(this.urlRegister,User)
}

}
