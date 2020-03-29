import { ListarFornecedoresComponent } from './components/fornecedores/listar-fornecedores/listar-fornecedores.component';
import { CriarEditarEmpresaComponent } from './components/empresas/criar-editar-empresa/criar-editar-empresa.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ListarEmpresaComponent } from './components/empresas/listar-empresa/listar-empresa.component';
import { CadastrarEditarFornecedoresComponent } from './components/fornecedores/cadastrar-editar-fornecedores/cadastrar-editar-fornecedores.component';


const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'empresas', component: ListarEmpresaComponent},
  {path: 'fornecedores', component: ListarFornecedoresComponent},
  {path: 'cadastrar-empresa/:id', component: CriarEditarEmpresaComponent},
  {path: 'cadastrar-empresa', component: CriarEditarEmpresaComponent},
  {path: 'cadastrar-fornecedor', component: CadastrarEditarFornecedoresComponent},
  {path: 'cadastrar-fornecedor/:id', component: CadastrarEditarFornecedoresComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
