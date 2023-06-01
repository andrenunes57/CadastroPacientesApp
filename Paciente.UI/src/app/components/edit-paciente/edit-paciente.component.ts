import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Convenio } from 'src/app/models/convenio';
import { Paciente } from 'src/app/models/paciente';
import { ConvenioService } from 'src/app/services/convenio.service';
import { PacienteService } from 'src/app/services/paciente.service';
import { FormGroup, FormBuilder, Validators, AbstractControl, ValidationErrors } from '@angular/forms';

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

  pacienteForm!: FormGroup;

  constructor(
    private pacienteService: PacienteService,
    private convenioService: ConvenioService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.convenioService
      .getConvenios()
      .subscribe((result: Convenio[]) => (this.convenios = result));

    this.initForm();
  }

  initForm() {
    this.pacienteForm = this.formBuilder.group<any>({
      celular: ['', Validators.required],
      telefone: ['', Validators.required],
    }, { validators: this.checkAtLeastOneFilled });
  }

  checkAtLeastOneFilled(formGroup: AbstractControl<any, any>): ValidationErrors | null {
  
    const celular = formGroup.get('celular')?.value;
    const telefone = formGroup.get('telefone')?.value;
  
    if (!celular && !telefone) {
      return { atLeastOneFilled: true };
    }
  
    return null;
  }

  onSubmit() {
    if (this.pacienteForm.valid) {
      const paciente: Paciente = {
        celular: this.pacienteForm.value.celular,
        telefone: this.pacienteForm.value.telefone,
        // Assign other properties as needed
      };

      if (this.paciente && this.paciente.id) {
        // Existing paciente, update
        this.updatePaciente(
          paciente,
          this.selectedConvenioId,
          this.selectedUfRG,
          this.selectedGenero
        );
      } else {
        // New paciente, create
        this.createPaciente(
          paciente,
          this.selectedConvenioId,
          this.selectedUfRG,
          this.selectedGenero
        );
      }
    }
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
      .subscribe((pacientes: Paciente[]) =>
        this.pacientesUpdated.emit(pacientes)
      );
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
        },
        error: (error) => {
          this.errorMessages = error.error as string[];
        },
      });
  }
}
