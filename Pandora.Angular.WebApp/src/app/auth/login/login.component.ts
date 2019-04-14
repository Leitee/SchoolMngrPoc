import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AuthService]
})
export class LoginComponent implements OnInit {
 

  constructor(private auth: AuthService, private router: Router) { }

  ngOnInit() {
  }
  login(form) {
    let body = { email: form.value.email, password: form.value.password }
    let resp = this.auth.login(body);
    resp.subscribe(value => {
      if (value) {
        localStorage.setItem('token', value.access_token);
        this.router.navigate(['/home'])
      }
    })

  }

}
