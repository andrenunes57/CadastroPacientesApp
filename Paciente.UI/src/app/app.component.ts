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
  convenios: Convenio[] = [];
  pacientes: Paciente[] = [];
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

  getConvenioNome(convenioId: number | undefined): string {
    if (convenioId === undefined) {
      return '';
    }
    
    const convenio = this.convenios.find(c => c.id === convenioId);
    return convenio ? convenio.nome : '';
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
