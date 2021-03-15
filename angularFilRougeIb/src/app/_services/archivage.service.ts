import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Archivage } from '../_models/archivage';

@Injectable({
  providedIn: 'root'
})
export class ArchivageService {

  constructor(private http : HttpClient) { }

  getbyidArchivage(id): Observable<any>{
    return this.http.get<Archivage[]>(`${environment.apiUrl}/api/archivages/${id}`)
  }

  postArchivage(body) : Observable<any>{
    return this.http.post<Archivage>(`${environment.apiUrl}/api/archivages`,body)
  }

}
