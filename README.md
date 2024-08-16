# Projeto API Doceria

API para conectar o [projeto doceria](https://github.com/Robemac2/Projeto-Doceria) com o banco de dados.

Página do projeto no [***DockerHub.***](https://hub.docker.com/repository/docker/robemac2/api-doceria/general)

---

## Tecnologias utilizadas
- Dotnet 8.0
- Docker
- Postgres

## Como rodar o projeto

### Preparando o ambiente

Para rodar o projeto é necessário ter o docker instalado na máquina.

Caso ainda nao tenha feito, instale o docker na sua máquina, para isso siga o tutorial no site oficial do [docker](https://docs.docker.com/get-docker/).

Também é necessário ter o postgres instalado na máquina, para isso siga o tutorial no site oficial do [postgres](https://www.postgresql.org/download/).

### Para rodar o projeto siga os passos abaixo:

1. Clone o repositório
2. Execute o comando `docker build .` na raiz do projeto
3. Execute o comando `docker run -d -p 8080:8080 -e DATABASE_URL=[0] DATABASE_PORT=[1] DATABASE_NAME=[2] DATABASE_USER=[3] DATABASE_PASSWORD=[4]` na raiz do projeto, substitua os valores `[0]`, `[1]`, `[2]`, `[3]` e `[4]` pelos valores de conexão com o banco de dados.

| Valor |     Variável      |               Descrição               |
|:-----:|:-----------------:|:-------------------------------------:|
|  [0]  |   DATABASE_URL    |  URL de conexão com o banco de dados  |
|  [1]  |   DATABASE_PORT   | Porta de conexão com o banco de dados |
|  [2]  |   DATABASE_NAME   |        Nome do banco de dados         |
|  [3]  |   DATABASE_USER   |       Usuário do banco de dados       |
|  [4]  | DATABASE_PASSWORD |        Senha do banco de dados        |

4. O projeto estará rodando na porta 8080