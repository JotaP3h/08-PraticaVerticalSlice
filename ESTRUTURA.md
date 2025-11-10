# 📁 Guia Visual da Estrutura do Projeto

## Estrutura Completa de Arquivos

```
AprendizadoVerticalSlice/
│
├── 📄 Program.cs                           # Ponto de entrada da aplicação
├── 📄 appsettings.json                     # Configurações da aplicação
├── 📄 AprendizadoVerticalSlice.csproj     # Arquivo do projeto .NET
├── 📄 README.md                            # Documentação principal (VOCÊ ESTÁ AQUI!)
├── 📄 requisicoes-exemplo.http             # Exemplos de requisições HTTP
├── 📄 .gitignore                           # Arquivos ignorados pelo Git
│
├── 📁 Funcionalidades/                     # 🎯 Todas as funcionalidades da aplicação
│   │
│   ├── 📁 Produtos/                        # 🎯 Slice: Produtos
│   │   │
│   │   ├── 📄 Produto.cs                   # Entidade Produto
│   │   │
│   │   ├── 📁 ObterTodosProdutos/          # ✅ Funcionalidade: Listar produtos
│   │   │   ├── 📄 ObterTodosProdutosHandler.cs
│   │   │   └── 📄 ObterTodosProdutosEndpoint.cs
│   │   │
│   │   ├── 📁 ObterProdutoPorId/           # ✅ Funcionalidade: Buscar produto por ID
│   │   │   ├── 📄 ObterProdutoPorIdHandler.cs
│   │   │   └── 📄 ObterProdutoPorIdEndpoint.cs
│   │   │
│   │   ├── 📁 CriarProduto/                # ✅ Funcionalidade: Criar produto
│   │   │   ├── 📄 CriarProdutoHandler.cs
│   │   │   └── 📄 CriarProdutoEndpoint.cs
│   │   │
│   │   ├── 📁 AtualizarProduto/            # ✅ Funcionalidade: Atualizar produto
│   │   │   ├── 📄 AtualizarProdutoHandler.cs
│   │   │   └── 📄 AtualizarProdutoEndpoint.cs
│   │   │
│   │   └── 📁 ExcluirProduto/              # ✅ Funcionalidade: Excluir produto
│   │       ├── 📄 ExcluirProdutoHandler.cs
│   │       └── 📄 ExcluirProdutoEndpoint.cs
│   │
│   └── 📁 Categorias/                      # 🎯 Slice: Categorias
│       │
│       ├── 📄 Categoria.cs                 # Entidade Categoria
│       │
│       ├── 📁 ObterTodasCategorias/        # ✅ Funcionalidade: Listar categorias
│       │   ├── 📄 ObterTodasCategoriasHandler.cs
│       │   └── 📄 ObterTodasCategoriasEndpoint.cs
│       │
│       ├── 📁 CriarCategoria/              # ✅ Funcionalidade: Criar categoria
│       │   ├── 📄 CriarCategoriaHandler.cs
│       │   └── 📄 CriarCategoriaEndpoint.cs
│       │
│       └── 📁 ObterCategoriaPorId/         # ❌ ATIVIDADE: Você vai implementar!
│           ├── 📄 ObterCategoriaPorIdHandler.cs     (A CRIAR)
│           └── 📄 ObterCategoriaPorIdEndpoint.cs    (A CRIAR)
│
└── 📁 Infraestrutura/                      # 🔧 Componentes de infraestrutura
    └── 📄 BancoDeDados.cs                  # Contexto do Entity Framework Core
```

## 🎯 Anatomia de uma Slice Completa

Vamos examinar a slice **CriarProduto** como exemplo:

```
📁 CriarProduto/
│
├── 📄 CriarProdutoHandler.cs
│   ├── 🔷 CriarProdutoRequisicao (record)
│   │   └── Define o que o cliente envia
│   │
│   ├── 🔷 CriarProdutoResposta (record)
│   │   └── Define o que a API retorna
│   │
│   └── 🔷 CriarProdutoHandler (classe)
│       ├── Recebe BancoDeDados via construtor
│       ├── Método Executar(requisicao)
│       ├── Valida os dados
│       ├── Aplica regras de negócio
│       ├── Persiste no banco de dados
│       └── Retorna o resultado
│
└── 📄 CriarProdutoEndpoint.cs
    └── 🔷 CriarProdutoEndpoint (classe estática)
        └── MapCriarProduto (método de extensão)
            ├── Define a rota: POST /api/produtos
            ├── Recebe CriarProdutoRequisicao do body
            ├── Injeta CriarProdutoHandler
            ├── Chama handler.Executar()
            ├── Trata o resultado
            └── Retorna resposta HTTP apropriada
```

## 🔄 Fluxo de uma Requisição

```
1. Cliente HTTP
   │
   │ POST /api/produtos
   │ { "nome": "Mouse", "preco": 100, ... }
   │
   ↓
2. ASP.NET Core Pipeline
   │
   │ Encontra o endpoint mapeado
   │
   ↓
3. CriarProdutoEndpoint
   │
   │ Recebe a requisição
   │ Deserializa o JSON → CriarProdutoRequisicao
   │ Resolve CriarProdutoHandler do container DI
   │
   ↓
4. CriarProdutoHandler
   │
   │ Executa validações
   │ Aplica regras de negócio
   │ Interage com o banco de dados
   │ Retorna resultado (sucesso, erro, dados)
   │
   ↓
5. CriarProdutoEndpoint
   │
   │ Trata o resultado do Handler
   │ Converte para resposta HTTP apropriada
   │ - 201 Created (sucesso)
   │ - 400 Bad Request (erro de validação)
   │
   ↓
6. Cliente HTTP
   │
   │ Recebe a resposta
   └─ Status code + JSON
```

## 📊 Comparação Visual: Camadas vs Vertical Slice

### Arquitetura em Camadas Tradicional

```
Cliente HTTP
    │
    ↓
┌─────────────────────────────────────────┐
│  📁 Controllers/                        │
│  - ProdutoController                    │  ← 1 arquivo para TODAS as operações
│  - CategoriaController                  │     de produto
└─────────────────────────────────────────┘
    │
    ↓
┌─────────────────────────────────────────┐
│  📁 Services/                           │
│  - ProdutoService                       │  ← Lógica de negócio centralizada
│  - CategoriaService                     │
└─────────────────────────────────────────┘
    │
    ↓
┌─────────────────────────────────────────┐
│  📁 Repositories/                       │
│  - ProdutoRepository                    │  ← Acesso a dados centralizado
│  - CategoriaRepository                  │
└─────────────────────────────────────────┘
    │
    ↓
┌─────────────────────────────────────────┐
│  📁 Models/                             │
│  - Produto                              │
│  - Categoria                            │
└─────────────────────────────────────────┘
    │
    ↓
Banco de Dados
```

**Problema:** Para adicionar "Criar Produto", preciso mexer em 4 arquivos diferentes!

### Vertical Slice Architecture

```
Cliente HTTP
    │
    ↓
┌─────────────────────────────────────────┐
│  📁 CriarProduto/                       │
│  ├── CriarProdutoHandler                │  ← TUDO relacionado a
│  └── CriarProdutoEndpoint               │     "Criar Produto" aqui!
└─────────────────────────────────────────┘
    │
    ↓
┌─────────────────────────────────────────┐
│  📁 ObterProdutoPorId/                  │
│  ├── ObterProdutoPorIdHandler           │  ← Funcionalidade isolada
│  └── ObterProdutoPorIdEndpoint          │
└─────────────────────────────────────────┘
    │
    ↓
┌─────────────────────────────────────────┐
│  📁 AtualizarProduto/                   │
│  ├── AtualizarProdutoHandler            │  ← Outra funcionalidade isolada
│  └── AtualizarProdutoEndpoint           │
└─────────────────────────────────────────┘
    │
    ↓ (todas as slices acessam)
┌─────────────────────────────────────────┐
│  📁 Infraestrutura/                     │
│  └── BancoDeDados (EF Core Context)     │
└─────────────────────────────────────────┘
    │
    ↓
Banco de Dados
```

**Vantagem:** Cada funcionalidade é independente e auto-contida!

## 🎨 Padrões Visuais de Nomenclatura

### Estrutura de Nomes

```
Verbo + Entidade + Contexto (opcional)
  │       │            │
  ↓       ↓            ↓
Obter + Produto + PorId

Exemplos:
✅ ObterTodosProdutos
✅ CriarProduto
✅ AtualizarProduto
✅ ExcluirProduto
✅ ObterProdutoPorId
✅ ObterProdutosPorCategoria
```

### Padrão de Pastas

```
📁 [VerbosEntidade]/
├── 📄 [VerbosEntidade]Handler.cs
└── 📄 [VerbosEntidade]Endpoint.cs

Exemplo:
📁 CriarProduto/
├── 📄 CriarProdutoHandler.cs
└── 📄 CriarProdutoEndpoint.cs
```

## 📋 Checklist de Implementação de uma Nova Slice

Quando for criar uma nova funcionalidade, siga este checklist:

### ✅ Passo 1: Criar a Estrutura
- [ ] Criar pasta com nome da funcionalidade
- [ ] Criar arquivo `*Handler.cs`
- [ ] Criar arquivo `*Endpoint.cs`

### ✅ Passo 2: Implementar o Handler
- [ ] Criar record de requisição (se necessário)
- [ ] Criar record de resposta
- [ ] Criar classe Handler
- [ ] Implementar construtor recebendo dependências
- [ ] Implementar método `Executar()`
- [ ] Adicionar validações
- [ ] Implementar lógica de negócio
- [ ] Retornar resultado apropriado

### ✅ Passo 3: Implementar o Endpoint
- [ ] Criar classe estática
- [ ] Criar método de extensão `Map*`
- [ ] Definir verbo HTTP correto (GET, POST, PUT, DELETE)
- [ ] Definir rota
- [ ] Mapear parâmetros de entrada
- [ ] Chamar o Handler
- [ ] Tratar resultado
- [ ] Retornar resposta HTTP apropriada
- [ ] Adicionar metadata (WithName, WithTags, Produces)

### ✅ Passo 4: Registrar no Program.cs
- [ ] Adicionar `using` do namespace
- [ ] Registrar Handler no DI: `builder.Services.AddScoped<*Handler>()`
- [ ] Mapear endpoint: `app.Map*()`

### ✅ Passo 5: Testar
- [ ] Compilar o projeto
- [ ] Executar a aplicação
- [ ] Testar via Swagger
- [ ] Testar cenários de sucesso
- [ ] Testar cenários de erro
- [ ] Verificar status codes

## 💡 Dicas de Organização

### 🎯 Uma Slice = Uma Responsabilidade

Cada slice deve fazer **apenas uma coisa**:

✅ **BOM:**
```
CriarProduto/        → Apenas cria produtos
ObterTodosProdutos/  → Apenas lista produtos
AtualizarProduto/    → Apenas atualiza produtos
```

❌ **RUIM:**
```
ProdutoOperacoes/    → Faz tudo relacionado a produtos
                      (muito abrangente!)
```

### 🔄 Compartilhamento de Código

**Regra de Ouro:** Se algo é usado por **3 ou mais slices**, considere extrair.

```
✅ Usado por 1-2 slices: Deixe duplicado
✅ Usado por 3+ slices: Considere extrair para Infraestrutura/
✅ Usado por todos: Definitivamente extraia
```

### 📦 Onde Colocar o Quê?

```
📁 Funcionalidades/[Entidade]/
  → Entidades do domínio
  → Slices específicas

📁 Infraestrutura/
  → DbContext (EF Core)
  → Classes utilitárias compartilhadas
  → Configurações de infraestrutura

📄 Program.cs
  → Configuração da aplicação
  → Registro de serviços
  → Mapeamento de endpoints
```

## 🎓 Para Saber Mais

Depois de completar a atividade prática, explore:

1. **Adicione mais validações complexas**
2. **Implemente paginação**
3. **Adicione filtros e ordenação**
4. **Implemente tratamento de erros global**
5. **Adicione logging**
6. **Escreva testes unitários**

---

**Continue sua jornada de aprendizado! 🚀**
