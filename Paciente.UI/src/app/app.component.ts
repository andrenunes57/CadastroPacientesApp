import { Component } from '@angular/core';
import { Paciente } from './models/paciente';
import { PacienteService } from './services/paciente.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Paciente.UI';
  pacientes: Paciente[] = [];

  constructor(private pacienteService: PacienteService) {}

  ngOnInit() : void {
    this.pacienteService
      .getPaciente()
      .subscribe((result: Paciente[]) => (this.pacientes = result));
  }
}
