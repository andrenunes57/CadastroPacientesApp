import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Convenio } from 'src/app/models/convenio';
import { Paciente } from 'src/app/models/paciente';
import { ConvenioService } from 'src/app/services/convenio.service';
import { PacienteService } from 'src/app/services/paciente.service';

@Component({
  selector: 'app-edit-paciente',
  templateUrl: './edit-paciente.component.html',
  styleUrls: ['./edit-paciente.component.css'],
})
export class EditPacienteComponent implements OnInit {
  convenios: Convenio[] = [];
  generos: string[] = [
    'Feminino',
    'Masculino',
    'Não-binário',
    'Outros',
    'Prefiro não responder',
  ];
  UFS: string[] = [
    'AC',
    'AL',
    'AP',
    'AM',
    'BA',
    'CE',
    'DF',
    'ES',
    'GO',
    'MA',
    'MT',
    'MS',
    'MG',
    'PA',
    'PB',
    'PR',
    'PE',
    'PI',
    'RJ',
    'RN',
    'RS',
    'RO',
    'RR',
    'SC',
    'SP',
    'SE',
    'TO',
  ];

  errorMessages: string[] = [];
  @Input() selectedGenero? = '';
  @Input() selectedUfRG? = '';
  @Input() selectedConvenioId?: number;
  @Input() paciente?: Paciente;
  @Output() pacientesUpdated = new EventEmitter<Paciente[]>();

  constructor(
    private pacienteService: PacienteService,
    private convenioService: ConvenioService
  ) {}

  ngOnInit(): void {
    this.convenioService
      .getConvenios()
      .subscribe((result: Convenio[]) => (this.convenios = result));
  }

  clearErrorMessages() {
    this.errorMessages = [];
  }

  updatePaciente(
    paciente: Paciente,
    selectedConvenioId?: number,
    selectedUfRG?: string,
    selectedGenero?: string
  ) {
    this.pacienteService
      .updatePaciente(
        paciente,
        selectedConvenioId,
        selectedUfRG,
        selectedGenero
      )
      .subscribe({
        next: (pacientes: Paciente[]) => {
          this.pacientesUpdated.emit(pacientes);
          alert(
            `Paciente "${paciente.nome} ${paciente.sobrenome}" atualizado com sucesso!`
          );
          this.clearErrorMessages();
        },
        error: (error) => {
          this.errorMessages = [error.error as string];
        },
      });
  }

  createPaciente(
    paciente: Paciente,
    selectedConvenioId?: number,
    selectedUfRG?: string,
    selectedGenero?: string
  ) {
    this.pacienteService
      .createPaciente(
        paciente,
        selectedConvenioId,
        selectedUfRG,
        selectedGenero
      )
      .subscribe({
        next: (pacientes: Paciente[]) => {
          this.pacientesUpdated.emit(pacientes);
          alert(
            `Paciente "${paciente.nome} ${paciente.sobrenome}" criado com sucesso!`
          );
          this.clearErrorMessages();
        },
        error: (error) => {
          this.errorMessages = [error.error as string];
        },
      });
  }
}
