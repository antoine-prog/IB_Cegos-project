import { Component } from '@angular/core';
import { AppService } from './app.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'angular-ib-cegos-filRouge';
  posts = []

  constructor(service: AppService) {
    service.getAll().then(posts => this.posts = posts)
  }
}
