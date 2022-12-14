import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Provincia } from 'src/app/models/provincia';
import { LoginService } from 'src/app/services/login.service';
import { Localidad } from 'src/app/models/localidad';
import { ProvinciasService } from 'src/app/services/provincias.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  ListaProvincias: any;
  ListaLocalidades: any;
  IdProvincia: any;
  selectedProvincia: any;
  
  onProvinciasSelected(p:any){
    console.log(p.target.value);
    this.IdProvincia=p.target.value;
    var IdProvincia = Number(p);
    console.log(IdProvincia);
    
    
    
    this.provinciasService.getLocalidadesList(IdProvincia).subscribe((data: any) =>{
      console.log(data);
      this.ListaLocalidades=data;
    })
  }
    
    

  constructor(private formBuilder: FormBuilder, private loginService:LoginService, private provinciasService: ProvinciasService) { 
  }

  ngOnInit(): void {
    
    this.provinciasService.getProvinciasList().subscribe((data: any) =>{
      console.log(data);
      this.ListaProvincias=data;
    })

    

  }

}
