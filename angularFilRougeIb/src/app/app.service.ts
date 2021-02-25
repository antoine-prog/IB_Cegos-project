import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor() { }

    getAll() {
    return fetch("https://jsonplaceholder.typicode.com/posts", {
        method: 'GET'
    })
    .then(response => response.json())
  }
}
