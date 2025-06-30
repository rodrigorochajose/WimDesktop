# Wim Desktop 7.0

## 🎯 Objetivo

Desenvolver um software para realização de exames radiográficos, corrigindo problemas de softwares existentes (CDR e WimDesktop) e adicionando novas funcionalidades. Também visa facilitar a integração com a SDK do iRay.



## 🛠️ Instalação e Execução em Ambiente de Desenvolvimento

### ✅ Pré-Requisitos

- Visual Studio Community  
- .NET Framework 4.8

---

### 🔽 1. Clonar este repositório

> O projeto/solução em C# foi iniciado com o nome `DMMDigital`. Próximo ao período de implantação, o projeto foi renomeado para `WimDesktop` para fins de padronização e melhor organização.  
> A pasta `DMMDigital` foi mantida neste repositório devido ao histórico de commits.

---

### 📁 2. Copiar a pasta `WimDesktopDB` para `C:\`

> A pasta `WimDesktopDB` está disponível em **[local a ser definido]**. Ela contém a estrutura necessária para o banco de dados e armazenamento das imagens.

#### Estrutura da pasta `WimDesktopDB`:

```
WimDesktopDB
├── bkp
│   └── Backups do banco de dados (.FDB)  
│       - Limitado a 200 arquivos (gerenciado pelo software)
│       - Ao atingir 201 backups, o mais antigo é excluído
│
├── db
│   ├── Firebird
│   │   └── Arquivos necessários para execução do Firebird embutido
│   └── WIMDESKTOPDB.FDB (arquivo principal do banco de dados)
│
├── img
│   └── {id_do_paciente}
│       ├── Informações do paciente (arquivo de texto)
│       └── {id_do_exame}
│           ├── recycle (imagens excluídas)
│           └── Imagens do exame
│
└── migration
    └── Arquivos usados para migração de dados de versões anteriores (WimDesktop antigo ou CDR)
```

---

### 📂 3. Abrir o Projeto

Abra a pasta `WimDesktop` e execute o arquivo `WimDesktop.csproj`. Isso abrirá diretamente o projeto no Visual Studio.

---
