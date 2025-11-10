# 🎉 Bem-vindo ao Roteiro de Aprendizagem: Vertical Slice Architecture

## 🚀 Início Rápido

### 1️⃣ Execute a Aplicação
```bash
dotnet run
```

### 2️⃣ Acesse a Documentação Interativa
Abra no navegador: **http://localhost:5156/scalar/v1**

### 3️⃣ Leia a Documentação
Abra o arquivo **[README.md](README.md)** para começar a aprender!

---

## 📚 Documentação Disponível

| Arquivo | Descrição |
|---------|-----------|
| **[README.md](README.md)** | 📖 Documentação principal completa com conceitos, atividades e referências |
| **[ESTRUTURA.md](ESTRUTURA.md)** | 🗂️ Guia visual da estrutura do projeto e padrões |
| **[GUIA-TESTES.md](GUIA-TESTES.md)** | 🧪 Como testar a aplicação e verificar sua implementação |
| **[requisicoes-exemplo.http](requisicoes-exemplo.http)** | 📬 Exemplos de requisições HTTP para testar |

---

## 🎯 O que você vai fazer?

1. ✅ **Aprender** os conceitos de Vertical Slice Architecture
2. ✅ **Explorar** o código de exemplo (2 slices completas)
3. ✅ **Implementar** uma nova funcionalidade do zero
4. ✅ **Testar** sua implementação
5. ✅ **Entregar** via fork do repositório

---

## 🏗️ Estrutura do Projeto

```
📁 Funcionalidades/
├── 📁 Produtos/        ✅ 5 funcionalidades implementadas
│   ├── ObterTodosProdutos/
│   ├── ObterProdutoPorId/
│   ├── CriarProduto/
│   ├── AtualizarProduto/
│   └── ExcluirProduto/
│
└── 📁 Categorias/      ✅ 2 funcionalidades + 1 para você implementar
    ├── ObterTodasCategorias/
    ├── CriarCategoria/
    └── ObterCategoriaPorId/  ❌ VOCÊ VAI IMPLEMENTAR ESTA!
```

---

## 🎓 Roteiro de Estudo Sugerido

### Parte 1: Teoria (30-45 minutos)
1. Leia a seção "O que é Vertical Slice Architecture?" no README
2. Entenda as diferenças entre arquitetura em camadas e vertical slice
3. Estude os conceitos fundamentais (Handler, Endpoint, Records)

### Parte 2: Exploração (30-45 minutos)
1. Execute a aplicação
2. Teste os endpoints existentes via Scalar
3. Analise o código da slice "CriarProduto" (está bem documentada!)
4. Compare com "ObterProdutoPorId" para ver um padrão GET

### Parte 3: Prática (1-2 horas)
1. Leia a seção "Atividade Prática" no README
2. Implemente "ObterCategoriaPorId" seguindo o passo a passo
3. Teste sua implementação usando o GUIA-TESTES.md
4. Certifique-se de que todos os testes passam

### Parte 4: Entrega (15 minutos)
1. Faça fork do repositório
2. Commit suas alterações
3. Envie o link do seu fork

---

## 💡 Dicas Importantes

### ✅ Antes de Começar
- [ ] .NET 8 SDK instalado
- [ ] Editor de código configurado (VS Code, Visual Studio ou Rider)
- [ ] Git instalado (para o fork)
- [ ] Conhecimentos básicos de C# e ASP.NET Core

### ✅ Durante o Desenvolvimento
- 📖 Consulte os exemplos existentes (são sua melhor referência!)
- 🧪 Teste frequentemente (compile e execute)
- 📝 Leia os comentários no código
- ❓ Use o README para tirar dúvidas

### ✅ Antes de Entregar
- [ ] Código compila sem erros
- [ ] Aplicação executa corretamente
- [ ] Todos os testes do GUIA-TESTES.md passam
- [ ] Endpoint aparece na documentação Scalar
- [ ] Código está comentado em português

---

## 🆘 Precisa de Ajuda?

### Problemas Comuns

**"A aplicação não compila"**
- Verifique se todos os `using` estão corretos
- Certifique-se de que os namespaces correspondem às pastas
- Execute `dotnet restore` e tente novamente

**"Não sei por onde começar a atividade"**
- Leia o README.md seção "Atividade Prática"
- Olhe a implementação de "ObterProdutoPorId" como exemplo
- Siga o passo a passo (sem pular etapas!)

**"Meu endpoint não aparece no Scalar"**
- Verifique se você registrou o Handler no Program.cs
- Verifique se você mapeou o Endpoint no Program.cs
- Reinicie a aplicação

**"Endpoint retorna erro 500"**
- Veja o console onde a aplicação está rodando
- O erro geralmente indica problema no Handler
- Verifique se as queries do Entity Framework estão corretas

---

## 🌟 Recursos do Projeto

### ✅ O que está implementado

- ✅ Estrutura completa de Vertical Slice Architecture
- ✅ Banco de dados em memória (EF Core InMemory)
- ✅ Dados iniciais para testes
- ✅ Documentação interativa (Scalar)
- ✅ 7 endpoints funcionando:
  - GET /api/categorias
  - POST /api/categorias
  - GET /api/produtos
  - GET /api/produtos/{id}
  - POST /api/produtos
  - PUT /api/produtos/{id}
  - DELETE /api/produtos/{id}

### ⚠️ O que você vai implementar

- ❌ GET /api/categorias/{id} - Obter categoria por ID

---

## 📖 Começando Agora

**Pronto para começar?**

1. Abra o **[README.md](README.md)**
2. Comece pela seção "Introdução"
3. Siga o roteiro completo
4. Boa aprendizagem! 🚀

---

## 🎯 Objetivo Final

Ao terminar este roteiro, você será capaz de:

✅ Explicar o que é Vertical Slice Architecture
✅ Identificar as diferenças entre VSA e arquitetura em camadas
✅ Criar uma nova funcionalidade completa do zero
✅ Organizar código por funcionalidades ao invés de camadas técnicas
✅ Aplicar esses conceitos em seus próprios projetos

---

**Desenvolvido com ❤️ para ensinar Vertical Slice Architecture**

📧 Dúvidas? Sugestões? Abra uma Issue no GitHub!

---

*Versão 1.0 - Novembro 2025*
