import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TransaccionesService {

  constructor() { 
    console.log("el servicio transacciones funciona");
  }
}
