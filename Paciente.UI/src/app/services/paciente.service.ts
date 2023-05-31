import { Injectable } from '@angular/core';
import { Paciente } from '../models/paciente';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PacienteService {
  private url = "v1/pacientes";

  constructor(private http: HttpClient) { }

  public getPaciente() : Observable<Paciente[]> {
    return this.http.get<Paciente[]>(`${environment.apiUrl}/${this.url}`)
  }
}
