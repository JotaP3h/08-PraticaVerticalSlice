# 🧪 Guia de Testes

## Como Testar a Aplicação

### 1. Usando o Navegador (Scalar UI)

A maneira mais fácil de testar é usando a interface Scalar:

1. Execute a aplicação:
   ```bash
   dotnet run
   ```

2. Abra o navegador em: `http://localhost:5156/scalar/v1`

3. Você verá uma interface moderna com todos os endpoints documentados

4. Clique em qualquer endpoint para ver os detalhes

5. Use o botão "Try it out" para testar diretamente

### 2. Testando os Endpoints

#### Teste 1: Listar Categorias (GET)

**Endpoint:** `GET /api/categorias`

**Resultado Esperado:** Status 200 com lista de 3 categorias iniciais

```json
[
  {
    "id": 1,
    "nome": "Eletrônicos",
    "descricao": "Produtos eletrônicos e tecnologia"
  },
  {
    "id": 2,
    "nome": "Livros",
    "descricao": "Livros e publicações"
  },
  {
    "id": 3,
    "nome": "Roupas",
    "descricao": "Vestuário e acessórios"
  }
]
```

#### Teste 2: Listar Produtos (GET)

**Endpoint:** `GET /api/produtos`

**Resultado Esperado:** Status 200 com lista de 2 produtos iniciais

```json
[
  {
    "id": 1,
    "nome": "Notebook Dell",
    "descricao": "Notebook Dell Inspiron 15",
    "preco": 3500.00,
    "quantidadeEstoque": 10,
    "categoriaId": 1,
    "nomeCategoria": "Eletrônicos"
  },
  {
    "id": 2,
    "nome": "Clean Code",
    "descricao": "Livro sobre código limpo por Robert Martin",
    "preco": 89.90,
    "quantidadeEstoque": 25,
    "categoriaId": 2,
    "nomeCategoria": "Livros"
  }
]
```

#### Teste 3: Criar Nova Categoria (POST)

**Endpoint:** `POST /api/categorias`

**Body:**
```json
{
  "nome": "Informática",
  "descricao": "Produtos de informática e acessórios"
}
```

**Resultado Esperado:** Status 201 Created

```json
{
  "id": 4,
  "nome": "Informática",
  "descricao": "Produtos de informática e acessórios"
}
```

#### Teste 4: Criar Novo Produto (POST)

**Endpoint:** `POST /api/produtos`

**Body:**
```json
{
  "nome": "Mouse Gamer",
  "descricao": "Mouse gamer RGB com 16.000 DPI",
  "preco": 150.00,
  "quantidadeEstoque": 50,
  "categoriaId": 1
}
```

**Resultado Esperado:** Status 201 Created

```json
{
  "id": 3,
  "nome": "Mouse Gamer",
  "descricao": "Mouse gamer RGB com 16.000 DPI",
  "preco": 150.00,
  "quantidadeEstoque": 50,
  "categoriaId": 1
}
```

#### Teste 5: Obter Produto Por ID (GET)

**Endpoint:** `GET /api/produtos/1`

**Resultado Esperado:** Status 200

```json
{
  "id": 1,
  "nome": "Notebook Dell",
  "descricao": "Notebook Dell Inspiron 15",
  "preco": 3500.00,
  "quantidadeEstoque": 10,
  "categoriaId": 1,
  "nomeCategoria": "Eletrônicos"
}
```

#### Teste 6: Produto Não Encontrado (GET)

**Endpoint:** `GET /api/produtos/999`

**Resultado Esperado:** Status 404 Not Found

```json
{
  "mensagem": "Produto com ID 999 não encontrado."
}
```

#### Teste 7: Atualizar Produto (PUT)

**Endpoint:** `PUT /api/produtos/1`

**Body:**
```json
{
  "nome": "Notebook Dell Atualizado",
  "descricao": "Notebook Dell Inspiron 15 com SSD 512GB",
  "preco": 3800.00,
  "quantidadeEstoque": 8,
  "categoriaId": 1
}
```

**Resultado Esperado:** Status 204 No Content

#### Teste 8: Validação - Nome Vazio (POST)

**Endpoint:** `POST /api/produtos`

**Body:**
```json
{
  "nome": "",
  "descricao": "Teste",
  "preco": 100.00,
  "quantidadeEstoque": 10,
  "categoriaId": 1
}
```

**Resultado Esperado:** Status 400 Bad Request

```json
{
  "mensagem": "O nome do produto é obrigatório."
}
```

#### Teste 9: Validação - Preço Inválido (POST)

**Endpoint:** `POST /api/produtos`

**Body:**
```json
{
  "nome": "Produto Teste",
  "descricao": "Teste",
  "preco": -10.00,
  "quantidadeEstoque": 10,
  "categoriaId": 1
}
```

**Resultado Esperado:** Status 400 Bad Request

```json
{
  "mensagem": "O preço deve ser maior que zero."
}
```

#### Teste 10: Validação - Categoria Inexistente (POST)

**Endpoint:** `POST /api/produtos`

**Body:**
```json
{
  "nome": "Produto Teste",
  "descricao": "Teste",
  "preco": 100.00,
  "quantidadeEstoque": 10,
  "categoriaId": 999
}
```

**Resultado Esperado:** Status 400 Bad Request

```json
{
  "mensagem": "Categoria com ID 999 não encontrada."
}
```

#### Teste 11: Excluir Produto (DELETE)

**Endpoint:** `DELETE /api/produtos/2`

**Resultado Esperado:** Status 204 No Content

**Verificação:** Tente buscar o produto deletado:
- `GET /api/produtos/2` deve retornar 404

### 3. Testando Sua Implementação (ObterCategoriaPorId)

Depois de implementar a atividade, teste:

#### Categoria Existente
**Endpoint:** `GET /api/categorias/1`

**Resultado Esperado:** Status 200

```json
{
  "id": 1,
  "nome": "Eletrônicos",
  "descricao": "Produtos eletrônicos e tecnologia"
}
```

#### Categoria Inexistente
**Endpoint:** `GET /api/categorias/999`

**Resultado Esperado:** Status 404 Not Found

```json
{
  "mensagem": "Categoria com ID 999 não encontrada."
}
```

## 🔍 Verificando Status Codes

| Status | Significado | Quando Ocorre |
|--------|-------------|---------------|
| 200 OK | Sucesso | GET retorna dados |
| 201 Created | Criado | POST cria novo recurso |
| 204 No Content | Sucesso sem conteúdo | PUT/DELETE bem sucedidos |
| 400 Bad Request | Requisição inválida | Validação falha |
| 404 Not Found | Não encontrado | Recurso não existe |

## 🐛 Problemas Comuns

### Erro: "Connection refused"
**Solução:** Certifique-se de que a aplicação está rodando (`dotnet run`)

### Erro 404 em todos os endpoints
**Solução:** Verifique se você está usando a porta correta (veja no console)

### Erro 400 ao criar produto
**Solução:** Verifique se o JSON está correto e todos os campos obrigatórios estão presentes

### Dados desaparecem ao reiniciar
**Comportamento esperado:** O banco é em memória, dados são perdidos ao reiniciar

## 📝 Dicas de Teste

1. **Sempre teste o caminho feliz primeiro** (dados válidos)
2. **Depois teste os cenários de erro** (dados inválidos)
3. **Verifique os status codes retornados**
4. **Leia as mensagens de erro com atenção**
5. **Use o Scalar para ver exemplos de request/response**

## ✅ Checklist de Testes da Atividade

Antes de entregar, verifique se:

- [ ] A aplicação compila sem erros
- [ ] A aplicação executa sem travar
- [ ] `GET /api/categorias/1` retorna status 200 com dados da categoria
- [ ] `GET /api/categorias/2` retorna status 200 com dados da categoria
- [ ] `GET /api/categorias/3` retorna status 200 com dados da categoria
- [ ] `GET /api/categorias/999` retorna status 404
- [ ] O endpoint aparece na documentação Scalar
- [ ] O endpoint tem o nome correto na tag "Categorias"
- [ ] A mensagem de erro 404 está em português
- [ ] Todos os outros endpoints continuam funcionando

---

**Bons testes! 🧪**
