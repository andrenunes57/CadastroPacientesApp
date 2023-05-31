import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Paciente } from 'src/app/models/paciente';
import { PacienteService } from 'src/app/services/paciente.service';

@Component({
  selector: 'app-edit-paciente',
  templateUrl: './edit-paciente.component.html',
  styleUrls: ['./edit-paciente.component.css'],
})
export class EditPacienteComponent implements OnInit {
  @Input() paciente?: Paciente;
  @Output() pacientesUpdated = new EventEmitter<Paciente[]>();

  constructor(private pacienteService: PacienteService) {}

  ngOnInit(): void {}

  updatePaciente(paciente: Paciente) {
    this.pacienteService
      .updatePaciente(paciente)
      .subscribe((pacientes: Paciente[]) =>
        this.pacientesUpdated.emit(pacientes)
      );
  }

  createPaciente(paciente: Paciente) {
    this.pacienteService
      .createPaciente(paciente)
      .subscribe((pacientes: Paciente[]) =>
        this.pacientesUpdated.emit(pacientes)
      );
  }
}
