import { CRUD_API } from './../../app.api';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ListagemFornecedores } from './listar-fornecedores/listar-fornecedores.model';
import { Observable } from 'rxjs';
import { Fornecedor } from './fornecedor.model';
import { CreateFornecedorModel } from './cadastrar-editar-fornecedores/models/create-fornecedor.model';
import { ObterFornecedorId } from './cadastrar-editar-fornecedores/models/obter-fornecedor.model';
import * as moment from 'moment';
import { UpdateFornecedorModel } from './cadastrar-editar-fornecedores/models/update-fornecedor.model';


@Injectable({
  providedIn: 'root'
})
export class FornecedoresService {

  constructor(private http: HttpClient) { }

  obterTodosOsFornecedores() : Observable<ListagemFornecedores> {
    return this.http.get<ListagemFornecedores>(`${CRUD_API}Fornecedor/listar`);
  }

  removerFornecedor(id: string) : Observable<void> {
    return this.http.delete<void>(`${CRUD_API}Fornecedor/${id}`);
  }

  cadastrarOuAtualizarFornecedor(fornecedor: Fornecedor): Observable<void> {
    if (fornecedor.id) {
      let updateFornecedor = new UpdateFornecedorModel();
      updateFornecedor.id = fornecedor.id;
      updateFornecedor.dadosPessoais = fornecedor.dadosPessoais;
      updateFornecedor.dataCadastro = fornecedor.dataCadastro;
      updateFornecedor.empresaId = fornecedor.empresa.id;
      updateFornecedor.identificadorReceitaFederal = fornecedor.identificadorReceitaFederal;
      updateFornecedor.nome = fornecedor.nome;

      return this.http.put<void>(`${CRUD_API}Fornecedor`, updateFornecedor);
    }

    let createFornecedor = new CreateFornecedorModel();
    createFornecedor.dadosPessoais = fornecedor.dadosPessoais;
    createFornecedor.dataCadastro = new Date();
    createFornecedor.empresaId = fornecedor.empresa.id;
    createFornecedor.identificadorReceitaFederal = fornecedor.identificadorReceitaFederal;
    createFornecedor.nome = fornecedor.nome;

    return this.http.post<void>(`${CRUD_API}Fornecedor`, createFornecedor);
  }

  obterFornecedorPeloId(id: string): Observable<ObterFornecedorId>{
    return this.http.get<ObterFornecedorId>(`${CRUD_API}Fornecedor/${id}`);
  }


}
