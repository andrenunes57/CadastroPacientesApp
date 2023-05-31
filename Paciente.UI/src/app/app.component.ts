import { Component } from '@angular/core';
import { Paciente } from './models/paciente';
import { PacienteService } from './services/paciente.service';
import { Convenio } from './models/convenio';
import { ConvenioService } from './services/convenio.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Paciente.UI';
  pacientes: Paciente[] = [];
  convenios: Convenio[] = [];
  pacienteToEdit?: Paciente;

  constructor(
    private pacienteService: PacienteService,
    private convenioService: ConvenioService
  ) {}

  ngOnInit(): void {
    this.pacienteService
      .getPacientes()
      .subscribe((result: Paciente[]) => (this.pacientes = result));

    this.convenioService
      .getConvenios()
      .subscribe((result: Convenio[]) => (this.convenios = result));
  }

  updatePacienteList(pacientes: Paciente[]) {
    this.pacientes = pacientes;
  }

  initNewPaciente() {
    this.pacienteToEdit = new Paciente();
  }

  editPaciente(paciente: Paciente) {
    this.pacienteToEdit = paciente;
  }
}
