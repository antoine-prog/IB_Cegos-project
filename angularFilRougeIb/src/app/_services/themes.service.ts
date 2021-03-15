import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Theme } from '../_models/theme';

@Injectable({
  providedIn: 'root'
})
export class ThemesService {

  constructor(private http : HttpClient) { }

  getAll() : Observable<Theme[]>{
    return this.http.get<Theme[]>(`${environment.apiUrl}/api/themes`)
  }
}
