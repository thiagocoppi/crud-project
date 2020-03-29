import { Empresa } from '../empresas/empresa.model';
import { DadosPessoais } from './dados.pessoais.model';

class Fornecedor {
    public id : string;
    public empresa : Empresa;
    public nome : String;
    public dataCadastro : Date;
    public dadosPessoais : DadosPessoais;
    public identificadorReceitaFederal : string;

    /**
     *
     */
    constructor() {
        this.empresa = new Empresa();
        this.dadosPessoais = new DadosPessoais();
    }
}


export { Fornecedor };