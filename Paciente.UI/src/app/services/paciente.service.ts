import { Injectable } from '@angular/core';
import { Paciente } from '../models/paciente';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PacienteService {
  private url = 'v1/pacientes';

  constructor(private http: HttpClient) {}

  public getPacientes(): Observable<Paciente[]> {
    return this.http.get<Paciente[]>(`${environment.apiUrl}/${this.url}`);
  }

  public updatePaciente(paciente: Paciente): Observable<Paciente[]> {
    return this.http.put<Paciente[]>(
      `${environment.apiUrl}/${this.url}/${paciente.id}`,
      paciente
    );
  }

  public createPaciente(paciente: Paciente): Observable<Paciente[]> {
    return this.http.post<Paciente[]>(
      `${environment.apiUrl}/${this.url}`,
      paciente
    );
  }
}
