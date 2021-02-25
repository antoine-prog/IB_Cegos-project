import { Component } from '@angular/core';
import { AppService } from './app.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
<<<<<<< HEAD:angular-ib-cegos-filRouge/src/app/app.component.ts  title = 'angular-ib-cegos-filRouge';
  posts = []

  constructor(service: AppService) {
    service.getAll().then(posts => this.posts = posts)
  }
=======
  title = 'angularFilRougeIb';
>>>>>>> amelle:angularFilRougeIb/src/app/app.component.ts
}
