import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { FormBuilder, FormGroup } from '@angular/forms'
import { Router } from '@angular/router';
import { Login } from 'src/app/models/login';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

user:any;


  form!: FormGroup;

  constructor(private formBuilder: FormBuilder, 
    private miServicio:LoginService, 
    private router:Router) {

    // validacion
    this.form = this.formBuilder.group({
      username: ['', [Validators.required, Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$')]],
      password: ['', [Validators.required]]
    })
  }

  get username()
  {
    return this.form.get("username");
  }

  get password()
  {
    return this.form.get("password");
  }

  ngOnInit(): void {
    
  }

  login() {

    if (this.form.valid) {

      let username=this.form.get('username')?.value;
      let password=this.form.get('password')?.value;

      let login: Login=new Login(username, password);
      this.miServicio.iniciarSesion(login).subscribe(data => {
        this.router.navigate(['dashboard'])
        console.log("Login is working");
      },
      
      dataError=>{
        alert("Se ha producido un error, contacte con el soporte");
      });


      

    }

    else {
      this.form.markAllAsTouched();
    }

  }

}
