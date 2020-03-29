import { Component, OnInit } from '@angular/core';
import { EmpresaService } from '../empresa.service';
import { Empresa } from '../empresa.model';
import { finalize } from 'rxjs/operators';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-listar-empresa',
  templateUrl: './listar-empresa.component.html',
  styleUrls: ['./listar-empresa.component.css']
})
export class ListarEmpresaComponent implements OnInit {

  constructor(private empresaService: EmpresaService, private spinner: NgxSpinnerService) { }

  public empresas : Empresa[] = [];
  public textoSemRegistros = "Cadastre a sua primeira empresa";
  public rotaSemRegistros = "/cadastrar-empresa";

  ngOnInit(): void {
    this.spinner.show();
    this.empresaService.listarEmpresas()
    .pipe(
      finalize(() => {
        this.spinner.hide();
      })
    )
    .subscribe(result => {
      this.empresas = result.empresas;
    });
  }

}
