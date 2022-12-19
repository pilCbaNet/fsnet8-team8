import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/models/user';
import { LoginService } from 'src/app/services/login.service';
import { ProvinciasService } from 'src/app/services/provincias.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {


  form!: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private loginService: LoginService,
    private provinciasService: ProvinciasService,
    private http: HttpClient) {
    this.form = this.formBuilder.group({
      nombre: ['', [Validators.required]],
      apellido: ['', [Validators.required]],
      correo: ['', [Validators.required]],
      dni: ['', [Validators.required]],
      password: ['', [Validators.required]],
      confirmPassword: ['', [Validators.required]],
      fechaNac: ['', [Validators.required]]
    })
  }

  get nombre() {
    return this.form.get("nombre");
  }

  get apellido() {
    return this.form.get("apellido");
  }

  get correo() {
    return this.form.get("correo");
  }

  get dni() {
    return this.form.get("dni");
  }

  get password() {
    return this.form.get("password");
  }

  get confirmPassword() {
    return this.form.get("confirmPassword");
  }

  get fechaNac() {
    return this.form.get("fechaNac");
  }

  ngOnInit(): void {


  }

  onUserCreated() {
    

      let nombreUsu = this.form.get('nombre')?.value;
      let apellidoUsu = this.form.get('apellido')?.value;
      let Dni = this.form.get('dni')?.value;
      let FechaNacUsu = this.form.get('fechaNac')?.value;
      let EmailUsu = this.form.get('correo')?.value;
      let PasswordUsu = this.form.get('password')?.value;

      let user: User = new User(nombreUsu, apellidoUsu, Dni, FechaNacUsu, EmailUsu, PasswordUsu);
      console.log(nombreUsu, apellidoUsu, Dni, FechaNacUsu, EmailUsu, PasswordUsu)
      console.log(user)
      this.loginService.registrarUsuario(user).subscribe(data => {
        console.log('register is working')
        console.log(data);
      });


    }

 



}
