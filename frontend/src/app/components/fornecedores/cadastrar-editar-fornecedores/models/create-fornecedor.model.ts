import { DadosPessoais } from "src/app/components/fornecedores/dados.pessoais.model";

class CreateFornecedorModel {
    constructor() {
        
    }

    public empresaId: String;
    public nome: String;
    public dataCadastro: Date;
    public dadosPessoais: DadosPessoais;
    public identificadorReceitaFederal: String;
}

export {CreateFornecedorModel};