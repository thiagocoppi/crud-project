import { Component, OnInit } from "@angular/core";
import { Fornecedor } from "../fornecedor.model";
import { FornecedoresService } from "../fornecedores.service";
import { NgxSpinnerService } from "ngx-spinner";
import { finalize } from "rxjs/operators";
import { ToastrService } from 'ngx-toastr';
import * as moment from 'moment';

@Component({
  selector: "app-listar-fornecedores",
  templateUrl: "./listar-fornecedores.component.html",
  styleUrls: ["./listar-fornecedores.component.css"]
})
export class ListarFornecedoresComponent implements OnInit {
  public fornecedores: Fornecedor[] = [];
  public mostrarFiltro: Boolean = false;
  public cpfCnpjFilter: string;
  public dataCadastroFilter: string;


  constructor(
    private fornecedorService: FornecedoresService,
    private spinner: NgxSpinnerService,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.spinner.show();
    this.obterTodosFornecedores();

  }

  removerFornecedor(id: string): void {
    this.spinner.show();
    this.fornecedorService
      .removerFornecedor(id)
      .pipe(
        finalize(() => {
          this.spinner.hide();
        })
      )
      .subscribe(() => {
        this.toastrService.success('Removido com sucesso!', 'Fornecedor');
        this.obterTodosFornecedores();
      });
  }

  obterTodosFornecedores(): void {
    this.spinner.show();
    this.fornecedorService
    .obterTodosOsFornecedores()
    .pipe(
      finalize(() => {
        this.spinner.hide();
      })
    )
    .subscribe(result => (this.fornecedores = result.fornecedores));
  }

  esconderMostrarFiltros() : void {
    this.mostrarFiltro = !this.mostrarFiltro;
  }

  filtrarFornecedores(): void {
    this.spinner.show();
    var dataFormatadaFiltrar = null;
    
    if (this.dataCadastroFilter) {
      var dataCadastroFiltradoString = `${this.dataCadastroFilter.substr(0,2)}/${this.dataCadastroFilter.substr(2,2)}/${this.dataCadastroFilter.substr(4)}`;
      dataFormatadaFiltrar = moment(dataCadastroFiltradoString, "DD/MM/YYYY").toDate();
    }

    this.fornecedorService.filtrarFornecedores(this.cpfCnpjFilter, dataFormatadaFiltrar)
    .pipe(
      finalize(() => {
        this.spinner.hide();
      })
    )
    .subscribe(result =>{
      this.fornecedores = [];
      this.fornecedores = result.fornecedores;
    } , 
    () => this.toastrService.error('Ocorre um erro ao filtrar', 'Fornecedores'));
  }

}


