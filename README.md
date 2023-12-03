# MiniERP em Windows Forms com .NET 6

Este é um projeto de MiniERP (Enterprise Resource Planning) desenvolvido em Windows Forms utilizando o framework .NET 6 e o Entity Framework para gerenciar o cadastro de produtos, fornecedores, clientes e o lançamento de notas fiscais. Além disso, o projeto inclui a funcionalidade de gerar um PDF da nota fiscal.

## Requisitos do Sistema

- [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/downloads/) (ou versão superior) instalado.
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) instalado.

## Configuração do Ambiente

1. Clone este repositório em sua máquina local:

    ```bash
    git clone https://github.com/diegoluanfs/MiniERP
    ```

2. Abra a solução no Visual Studio 2022.

3. Restaure as dependências do NuGet.

4. Configure o banco de dados no arquivo `appsettings.json` com as informações de conexão desejadas.

    ```json
    "ConnectionStrings": {
        "DefaultConnection": "sua-string-de-conexao-aqui"
    }
    ```

5. Abra o Console do Gerenciador de Pacotes e execute o seguinte comando para aplicar as migrações e criar o banco de dados:

    ```bash
    Update-Database
    ```

6. Execute o projeto.

## Funcionalidades

### Cadastro de Produtos

- Crie e mantenha o cadastro de produtos, incluindo informações como nome, preço, quantidade em estoque, etc.

### Cadastro de Fornecedores

- Gerencie o cadastro de fornecedores, associando cada produto a um fornecedor.

### Cadastro de Clientes

- Mantenha informações detalhadas sobre seus clientes.

### Lançamento de Nota Fiscal

- Realize o lançamento de notas fiscais, associando clientes e produtos em uma relação N x N.

### Gerar PDF da Nota Fiscal

- Gere arquivos PDF das notas fiscais para facilitar o armazenamento e compartilhamento.

## Telas

1. **Tela de Cadastro de Produtos**

    ![Cadastro de Produtos](screenshots/cadastro_produtos.png)

2. **Tela de Cadastro de Fornecedores**

    ![Cadastro de Fornecedores](screenshots/cadastro_fornecedores.png)

3. **Tela de Cadastro de Clientes**

    ![Cadastro de Clientes](screenshots/cadastro_clientes.png)

4. **Tela de Lançamento de Nota Fiscal**

    ![Lançamento de Nota Fiscal](screenshots/lancamento_nota.png)

5. **Tela de Geração de PDF da Nota Fiscal**

    ![Geração de PDF](screenshots/geracao_pdf.png)

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues, enviar pull requests ou fornecer feedback.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

---

Espero que este readme seja útil para começar com o seu projeto MiniERP em Windows Forms com .NET 6! Se precisar de ajuda ou tiver dúvidas, não hesite em entrar em contato. Boa codificação!