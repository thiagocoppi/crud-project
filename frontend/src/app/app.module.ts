import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { HomeComponent } from './components/home/home.component';
import { CriarEditarEmpresaComponent } from './components/empresas/criar-editar-empresa/criar-editar-empresa.component';
import { ListarEmpresaComponent } from './components/empresas/listar-empresa/listar-empresa.component';
import { EmpresaService } from './components/empresas/empresa.service';
import { HttpClientModule } from '@angular/common/http';
import { NgxSpinnerModule } from 'ngx-spinner';
import { NgxMaskModule, IConfig } from 'ngx-mask'
import { FormsModule } from '@angular/forms';
import { ListarFornecedoresComponent } from './components/fornecedores/listar-fornecedores/listar-fornecedores.component';
import { CadastrarEditarFornecedoresComponent } from './components/fornecedores/cadastrar-editar-fornecedores/cadastrar-editar-fornecedores.component';
import { IdentificadorService } from './utils/identificador.service';
import { ToastrModule } from 'ngx-toastr';
import { NoRegistersFoundComponent } from './components/no-registers-found/no-registers-found.component';

export const options: Partial<IConfig> | (() => Partial<IConfig>) = {};

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    CriarEditarEmpresaComponent,
    ListarEmpresaComponent,
    ListarFornecedoresComponent,
    CadastrarEditarFornecedoresComponent,
    NoRegistersFoundComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    NgxSpinnerModule,
    ToastrModule.forRoot(),
    NgxMaskModule.forRoot(options)
  ],
  providers: [
    EmpresaService,
    IdentificadorService
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  bootstrap: [AppComponent]
})
export class AppModule { }
