# MiniERP em Windows Forms com .NET 6

Este � um projeto de MiniERP (Enterprise Resource Planning) desenvolvido em Windows Forms utilizando o framework .NET 6 e o Entity Framework para gerenciar o cadastro de produtos, fornecedores, clientes e o lan�amento de notas fiscais. Al�m disso, o projeto inclui a funcionalidade de gerar um PDF da nota fiscal.

## Requisitos do Sistema

- [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/downloads/) (ou vers�o superior) instalado.
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) instalado.

## Configura��o do Ambiente

1. Clone este reposit�rio em sua m�quina local:

    ```bash
    git clone https://github.com/diegoluanfs/MiniERP
    ```

2. Abra a solu��o no Visual Studio 2022.

3. Restaure as depend�ncias do NuGet.

4. Configure o banco de dados no arquivo `appsettings.json` com as informa��es de conex�o desejadas.

    ```json
    "ConnectionStrings": {
        "DefaultConnection": "sua-string-de-conexao-aqui"
    }
    ```

5. Abra o Console do Gerenciador de Pacotes e execute o seguinte comando para aplicar as migra��es e criar o banco de dados:

    ```bash
    Update-Database
    ```

6. Execute o projeto.

## Funcionalidades

### Cadastro de Produtos

- Crie e mantenha o cadastro de produtos, incluindo informa��es como nome, pre�o, quantidade em estoque, etc.

### Cadastro de Fornecedores

- Gerencie o cadastro de fornecedores, associando cada produto a um fornecedor.

### Cadastro de Clientes

- Mantenha informa��es detalhadas sobre seus clientes.

### Lan�amento de Nota Fiscal

- Realize o lan�amento de notas fiscais, associando clientes e produtos em uma rela��o N x N.

### Gerar PDF da Nota Fiscal

- Gere arquivos PDF das notas fiscais para facilitar o armazenamento e compartilhamento.

## Telas

1. **Tela de Cadastro de Produtos**

    ![Cadastro de Produtos](screenshots/cadastro_produtos.png)

2. **Tela de Cadastro de Fornecedores**

    ![Cadastro de Fornecedores](screenshots/cadastro_fornecedores.png)

3. **Tela de Cadastro de Clientes**

    ![Cadastro de Clientes](screenshots/cadastro_clientes.png)

4. **Tela de Lan�amento de Nota Fiscal**

    ![Lan�amento de Nota Fiscal](screenshots/lancamento_nota.png)

5. **Tela de Gera��o de PDF da Nota Fiscal**

    ![Gera��o de PDF](screenshots/geracao_pdf.png)

## Contribui��es

Contribui��es s�o bem-vindas! Sinta-se � vontade para abrir issues, enviar pull requests ou fornecer feedback.

## Licen�a

Este projeto est� licenciado sob a [MIT License](LICENSE).

---

Espero que este readme seja �til para come�ar com o seu projeto MiniERP em Windows Forms com .NET 6! Se precisar de ajuda ou tiver d�vidas, n�o hesite em entrar em contato. Boa codifica��o!