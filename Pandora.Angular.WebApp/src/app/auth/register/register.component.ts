import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from "@angular/router"

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers: [AuthService]
})
export class RegisterComponent implements OnInit {

  constructor(private auth: AuthService, private router: Router,
  ) { }




  ngOnInit() {
  }

  register(form) {
    let body = { email: form.value.email, name: form.value.name, password: form.value.password, role: form.value.role };

    let resp = this.auth.register(body);
    resp.subscribe(value => {
      if (value) {
        localStorage.setItem('token', value.access_token);
        this.router.navigate(['/home'])
      }
    })

  }


}
