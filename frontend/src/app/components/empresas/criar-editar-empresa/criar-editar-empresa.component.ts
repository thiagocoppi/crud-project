import { finalize } from 'rxjs/operators';
import { EmpresaService } from './../empresa.service';
import { Component, OnInit } from '@angular/core';
import { Empresa } from '../empresa.model';
import { NgxSpinnerService } from 'ngx-spinner';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-criar-editar-empresa',
  templateUrl: './criar-editar-empresa.component.html',
  styleUrls: ['./criar-editar-empresa.component.css']
})
export class CriarEditarEmpresaComponent implements OnInit {

  constructor(private empresaService: EmpresaService, private spinner: NgxSpinnerService, 
    private route: ActivatedRoute, private router: Router, private toastrService: ToastrService) 
  { }

  public ufs : String[] = ['RO','AC','AM','RR','PA','AP','TO','MA','PI','CE','RN','PB','PE','AL','SE','BA','MG','ES','RJ','SP','PR','SC','RS','MS','MT','GO','DF'];
  public empresa: Empresa = new Empresa();
  public ufSelect: String = 'Selecione';
  
  ngOnInit(): void {
    if (this.route.snapshot.params.id) {
      this.spinner.show();
      this.empresaService.buscarEmpresaPeloId(this.route.snapshot.params.id)
      .pipe(finalize(() => {
        this.spinner.hide();
      }))
      .subscribe(result => {
        this.empresa = result.empresa;
        this.ufSelect = result.empresa.uf;
      });
    }
  }

  onChange(event : any) {
    this.empresa.uf = event;
  }

  cadastrarOuAtualizarEmpresa(): void {
    this.spinner.show();
    if (this.empresa.id) {      
      this.empresaService.atualizarEmpresa(this.empresa)
      .pipe(finalize(() => {
        this.spinner.hide();
      }))
      .subscribe(() => {
        this.toastrService.success('Empresa atualizada com sucesso!', 'Empresa');
        this.router.navigateByUrl('/empresas');
      });
      return;
    }

    this.empresaService.cadastrarEmpresa(this.empresa)
      .pipe(finalize(() => {
        this.spinner.hide();
      }))
      .subscribe(() => {
        this.toastrService.success('Empresa cadastrada com sucesso!', 'Empresa');
        this.router.navigateByUrl('/empresas');
      }, (err) => {
        if (err.status == 400) {
          var errorsValidation = err.error.errors;
          for(var item in errorsValidation) {
            this.toastrService.error(err.error.errors[item], 'Empresa');
          }

          return;
        }
        
        this.toastrService.error('Ocorreu um erro interno', 'Empresa');
        
      });
  }

}
