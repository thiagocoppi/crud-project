import { Component, OnInit } from '@angular/core';
import { Fornecedor } from '../fornecedor.model';
import { FornecedoresService } from '../fornecedores.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-listar-fornecedores',
  templateUrl: './listar-fornecedores.component.html',
  styleUrls: ['./listar-fornecedores.component.css']
})
export class ListarFornecedoresComponent implements OnInit {
  public fornecedores : Fornecedor[] = [];

  constructor(private fornecedorService: FornecedoresService, private spinner: NgxSpinnerService) { }
  
  ngOnInit(): void {
    this.spinner.show();
    
    this.fornecedorService.obterTodosOsFornecedores()
    .pipe(
      finalize(() => {
        this.spinner.hide();
      })
    )
    .subscribe(result => this.fornecedores = result.fornecedores);
  }

  removerFornecedor(id: string): void {
    this.spinner.show();
    this.fornecedorService.removerFornecedor(id)
    .pipe(
      finalize(() => {
        this.spinner.hide();
      })
    )
    .subscribe(() => {
      //Add toastr
    });
  }

}
