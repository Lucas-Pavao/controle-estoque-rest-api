# Controle de Estoque API

**Descrição do Projeto**

Esta é uma API REST em desenvolvimento destinada ao controle de estoque. A aplicação tem como objetivo fornecer operações CRUD (Create, Read, Update, Delete) para produtos e usuários, visando facilitar a gestão eficiente dos itens armazenados.

## Funcionalidades Atuais

### Produtos

- **Listagem de Produtos:**
  - Consulta a lista completa de produtos no estoque.

- **Detalhes de Produto por ID:**
  - Recupera informações detalhadas de um produto específico com base no seu identificador único.

- **Adição de Produto:**
  - Permite a inclusão de novos produtos no estoque.

- **Atualização de Produto por ID:**
  - Modifica as propriedades de um produto existente com base no seu identificador único.

- **Remoção de Produto por ID:**
  - Exclui um produto do estoque com base no seu identificador único.

### Usuários

- **Listagem de Usuários:**
  - Consulta a lista completa de usuários registrados.

- **Detalhes de Usuário por ID:**
  - Recupera informações detalhadas de um usuário específico com base no seu identificador único.

**Observações Importantes:**
- Atualmente, a aplicação está focada na funcionalidade básica de controle de estoque.
- Este projeto é uma iniciativa de estudo e está em constante evolução.
- Futuras implementações incluirão recursos avançados de autenticação, autorização e melhorias na interface.

## Tecnologias Utilizadas

- **ASP.NET Core:** Framework de desenvolvimento para construção de aplicativos web modernos e escaláveis.
- **C#:** Linguagem de programação utilizada no desenvolvimento da aplicação.
- **Entity Framework Core:** Mapeamento objeto-relacional (ORM) para interagir com o banco de dados.
- **Moq:** Biblioteca de mocking para auxiliar nos testes unitários.
- **XUnit:** Framework de testes para testes unitários.

## Como Testar

Para testar a aplicação, siga os passos abaixo:

1. **Requisitos:**
   - Certifique-se de ter o [ASP.NET Core SDK](https://dotnet.microsoft.com/download) instalado na sua máquina.

2. **Clone o Repositório:**
   ```bash
   git clone https://github.com/seu-usuario/ControleDeEstoque.git
   cd ControleDeEstoque
   ```

3. **Execute a Aplicação:**
   ```bash
   dotnet run
   ```

4. **Testes Unitários:**
   ```bash
   dotnet test
   ```

5. **Acesso à API:**
   - A API estará acessível em `http://localhost:5000` por padrão.

6. **Documentação da API:**
   - Utilize ferramentas como [Swagger](https://swagger.io/) para explorar e testar os endpoints da API.

## Observações

Este projeto está em constante desenvolvimento e destina-se principalmente ao estudo e prática de conceitos relacionados a APIs REST, ASP.NET Core e controle de estoque. Sugestões e contribuições são bem-vindas!

**Autor:** Lucas Pavão
**Email:** lucaspavao89@gmail.com
