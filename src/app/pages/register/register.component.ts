import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
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

user:any;
form!: FormGroup;

  constructor(private formBuilder: FormBuilder, 
    private loginService: LoginService, 
    private provinciasService: ProvinciasService) {
      this.form = this.formBuilder.group({

      })
  }

  ngOnInit(): void {
    

  }

  register(){
    if (this.form.valid)
    {
      let name=this.form.get('name')?.value;
      let surname=this.form.get('surname')?.value;
      let email=this.form.get('email')?.value;
      let password=this.form.get('password')?.value;
      let confirmPassword=this.form.get('confirmPassword')?.value;
      let birthDate=this.form.get('birthDate')?.value;
    }

    else 
    {
      this.form.markAsTouched();
    }
  }

}
