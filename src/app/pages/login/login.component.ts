import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { FormBuilder, FormGroup } from '@angular/forms'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  form!: FormGroup;

  constructor(private formBuilder: FormBuilder) {
    this.form = this.formBuilder.group({
      usuario: ['', [Validators.required, Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$')]],
      password: ['', [Validators.required]]
    })
  }

  get usuario()
  {
    return this.form.get("usuario");
  }

  get password()
  {
    return this.form.get("password");
  }

  ngOnInit(): void {
  }

  login() {

    if (this.form.valid) {

      alert("Login is working");


    }

    else {
      alert("error en el logueo")
    }

  }

}
