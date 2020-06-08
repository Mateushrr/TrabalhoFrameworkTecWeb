# TrabalhoFrameworkTecWeb

Trabalho de conclusão da disciplina Tecnologias Web, do curso Sistemas de informação da PUCMinas unidade Barreiro.
Nesta atividade foi utilizado:
>
* Asp net MVC (https://docs.microsoft.com/pt-br/aspnet/mvc/overview/getting-started/introduction/getting-started)  
* Estratégia Dao (Data Access Object) - (https://pt.wikipedia.org/wiki/Objeto_de_acesso_a_dados)  
* Mysql 8.0.2 (https://dev.mysql.com/downloads/installer/)  
* MySql.Data.8.0.20 - Pacote no Nuget (ele quem permitirá manipular o mysql).

## Instruções

### Clonar o repositório:
```
git clone https://github.com/Mateushrr/TrabalhoFrameworkTecWeb.git
```

### Acessar o diretório

```
cd TrabalhoFrameworkTecWeb
```

### Abrir o arquivo o projeto (**TecWeb.sln**)  

Após abertura do projeto, vá até o gerenciador de soluções e faça:  
**É necessário pois o .gitignore evita que esses arquivos sobem para o repositório.**  

1. Limpe o projeto.  
![Limpeza](/screenshots/limpar.jpg "Limpar")  

2. selecione o projeto e marque-o como projeto de inicialização.  
![Inicializacao](/screenshots/projeto_inicializacao.jpg "Inicializacao")  

3. Recompile o projeto.  
![Rebuild](/screenshots/rebuild.jpg "Rebuild")

### Instalar o mysql e configurar o banco de dados.  
Se não tiver mysql instalado, **recomendo usar a versão 8.0.20**  

1. No gerenciador de soluções, encontre a **classe Conexao.cs na pasta Dao** do projeto.  
![ConexaoClasseLocal](/screenshots/conexao.jpg "ConexaoClasseLocal")  

2. Edite a linha 11 de acordo com seu banco de dados.  
![ClasseConexao](/screenshots/classe_conexao_linha11.jpg "ClasseConexao")  

3. Nossa estrutura do banco de dados.  
![BancoConfigurado](/screenshots/banco_de_dados.jpg "BancoConfigurado")  

### Código SQL utilizado.  

create database dbcrud;  
use dbcrud;  

create table pessoa(  
id int(10) unsigned not null auto_increment,  
cpf varchar(14),  
nome varchar(50),  
idade int (3),  
email varchar(50), primary key(id)  
);  
