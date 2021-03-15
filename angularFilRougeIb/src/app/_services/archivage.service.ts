import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Archivage } from '../_models/archivage';
import { PostArchivage } from '../_models/postarchivage';

@Injectable({
  providedIn: 'root'
})
export class ArchivageService {

  constructor(private http : HttpClient) { }

  getbyidArchivage(id): Observable<any>{
    return this.http.get<Archivage[]>(`${environment.apiUrl}/api/archivages/${id}`)
  }

  getbyidCreator(id) : Observable<any>{
    return this.http.get<Archivage[]>(`${environment.apiUrl}/api/archivages/ArchivagesCreator/${id}`)
  }
  postArchivage(body) : Observable<any>{
    return this.http.post<PostArchivage>(`${environment.apiUrl}/api/archivages`,body)
  }

}
