import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Convenio } from '../models/convenio';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ConvenioService {
  private url = 'v1/convenios';

  constructor(private http: HttpClient) { }

  public getConvenios(): Observable<Convenio[]> {
    return this.http.get<Convenio[]>(`${environment.apiUrl}/${this.url}`);
  }
}
