import { FornecedoresService } from './../fornecedores.service';
import { EmpresaService } from "./../../empresas/empresa.service";
import { Component, OnInit } from "@angular/core";
import { Fornecedor } from "../fornecedor.model";
import { Empresa } from "../../empresas/empresa.model";
import { finalize } from "rxjs/operators";
import { NgxSpinnerService } from "ngx-spinner";
import { IdentificadorService } from "src/app/utils/identificador.service";
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: "app-cadastrar-editar-fornecedores",
  templateUrl: "./cadastrar-editar-fornecedores.component.html",
  styleUrls: ["./cadastrar-editar-fornecedores.component.css"]
})
export class CadastrarEditarFornecedoresComponent implements OnInit {
  constructor(
    private empresaService: EmpresaService,
    private spinner: NgxSpinnerService,
    private identificadorService: IdentificadorService,
    private fornecedorService: FornecedoresService,
    private route: ActivatedRoute,
    private router: Router,
    private toatrService: ToastrService
  ) {}

  public fornecedor: Fornecedor = new Fornecedor();
  public empresas: Empresa[] = [];
  public showDadosPessoas: Boolean = false;
  public cpfCnpjInvalido: Boolean = false;
  public dataNascimento : string;
  public dataCadastro: string;

  ngOnInit(): void {
    this.spinner.show();
    
    this.empresaService
      .listarEmpresas()
      .pipe(
        finalize(() => {
          this.spinner.hide();
        })
      )
      .subscribe(result => {
        this.empresas = result.empresas;
      });

    if (this.route.snapshot.params.id) {
      this.spinner.show();
      this.fornecedorService.obterFornecedorPeloId(this.route.snapshot.params.id)
      .pipe(
        finalize(() => {
          this.spinner.hide();
        })
      )
      .subscribe(result => {
        this.fornecedor = result.fornecedor;
        this.showDadosPessoas = this.identificadorService.isCPF(this.fornecedor.identificadorReceitaFederal);
        if (this.showDadosPessoas) {
          this.dataNascimento = moment(this.fornecedor.dadosPessoais.dataNascimento).format('DD/MM/YYYY');
          this.dataCadastro = moment(this.fornecedor.dataCadastro).format('DD/MM/YYYY');
        }
      })
      return;
    }

  }

  onChange(id: string): void {
    this.fornecedor.empresa.id = id;
  }

  verificarCPfCnpj(value: string) {
    if (value.length < 11) {
      this.showDadosPessoas = false;
      return;
    }

    if (value.length == 11) {
      this.cpfCnpjInvalido = this.identificadorService.isCPF(value);
      this.showDadosPessoas = this.cpfCnpjInvalido;
      return;
    }

    this.showDadosPessoas = false;

    this.cpfCnpjInvalido = this.identificadorService.isCNPJ(value);
  }

  cadastrarOuAtualizar() {
    if (this.dataNascimento) {
      var dataNascimentoFormatada = `${this.dataNascimento.substr(0,2)}/${this.dataNascimento.substr(2,2)}/${this.dataNascimento.substr(4)}`;
      this.fornecedor.dadosPessoais.dataNascimento = moment(dataNascimentoFormatada, "DD/MM/YYYY").toDate();
    }

    if (this.fornecedor.id) {
      var dataCadastroFormatada = `${this.dataCadastro.substr(0,2)}/${this.dataCadastro.substr(2,2)}/${this.dataCadastro.substr(4)}`;
      this.fornecedor.dataCadastro = moment(dataCadastroFormatada, "DD/MM/YYYY").toDate();
    }

    this.spinner.show();
    this.fornecedorService.cadastrarOuAtualizarFornecedor(this.fornecedor)
    .pipe(
      finalize(() => {
        this.spinner.hide();
      })
    )
    .subscribe(() => {
      this.toatrService.success('Fornecedor atualizado!', 'Fornecedor');
      this.router.navigateByUrl('/fornecedores');
    }, (err) => {
      if (err.status == 400) {
        var errorsValidation = err.error.errors;
        if (errorsValidation){
          for(var item in errorsValidation) {
            this.toatrService.error(err.error.errors[item], 'Fornecedor');
          }
        } else {
          for(let errorItem in err.error.Errors){
            var mensagemItem = err.error.Errors[errorItem];
            this.toatrService.error(mensagemItem.Message, 'Fornecedor');
          }
        }

        return;
      }

      this.toatrService.error('Ocorreu um erro interno', 'Fornecedor');
    })
  }
}
