export class Paciente {
  id?: number;
  nome = '';
  sobrenome = '';
  dataNascimento: Date = new Date();
  genero = '';
  cpf = '';
  rg = '';
  ufRG = '';
  email = '';
  celular = '';
  telefone = '';
  carteirinha = '';
  carteirinhaValidade: Date = new Date();
  convenioId: number = 0;
}
