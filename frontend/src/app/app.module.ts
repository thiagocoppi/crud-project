import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
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

export const options: Partial<IConfig> | (() => Partial<IConfig>) = {};

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    CriarEditarEmpresaComponent,
    ListarEmpresaComponent,
    ListarFornecedoresComponent,
    CadastrarEditarFornecedoresComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    NgxSpinnerModule,
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