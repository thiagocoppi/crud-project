import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { CRUD_API } from 'src/app/app.api';
import { ListagemEmpresas } from './listar-empresa/listar-empresa.model';
import { Empresa } from './empresa.model';
import { EmpresaBuscar } from './criar-editar-empresa/empresa-buscar.model';

@Injectable({
  providedIn: 'root'
})
export class EmpresaService {

  constructor(private http: HttpClient) { }


  listarEmpresas(): Observable<ListagemEmpresas> {
    return this.http.get<ListagemEmpresas>(`${CRUD_API}Empresa`);
  }

  cadastrarEmpresa(empresa: Empresa): Observable<Empresa> {
    return this.http.post<Empresa>(`${CRUD_API}Empresa`, empresa);
  }

  buscarEmpresaPeloId(id: string): Observable<EmpresaBuscar> {
    return this.http.get<EmpresaBuscar>(`${CRUD_API}Empresa/${id}`);
  }

  atualizarEmpresa(empresa: Empresa): Observable<void> {
    return this.http.put<void>(`${CRUD_API}Empresa`, empresa);
  }

}
