# teste_dotnet
Teste de desenvolvimento .NET (C#) - AMcom

Web API que permite consultar e listar as 5 Unidades Básicas de Saúde (UBSs) mais próximas das coordenadas de latitude e longitude informadas.

### Solução

A solução está divida nas seguintes camadas:


* Services - Camada de lógica de aplicação.
* Services Interface - Interface para acesso da camada Service.
* IoC - Camada de Injeção de Dependencia.
* DAL - Camada de acesso a dados.
* DAL Interface - Interface para acesso da camada DAL.
* Test - Camada de Testes.
* Web API - Camada de Web API que expoem:

    * **GetUbs** - Retorna lista de UBS
    * **GetUbsByID(int Id)** - Retorna UBS por ID
    * **Add(UbsDTO ubs)** - Adiciona uma nova UBS
    * **AddRange(IEnumerable<UbsDTO> ubsList)** - Adiciona uma lista de UBS 
    * **Delete(int Id)** - Deleta uma UBS
    * **GetByLocationAsync(double latitude, double longitude, int count)** - Buscar uma quantidade especifica(count) de UBS mais proximas informando Latitude e Longitude
    * **ImportCsvUbs(string path)** - Importa um arquivo CSV (arquivo exemplo encontrado na pasta Resources)
    * **GetDistancia(double latitude, double longitude)** - Listar as distancias informando latitude e longitude

### Estrutuda da Aplicação

src\AMcom.Teste.WebApi

src\AMcom.Teste.Service

src\AMcom.Teste.Service.Interface

src\AMcom.Teste.Ioc

src\AMcom.Teste.DAL

src\AMcom.Teste.DAL.Interface

test\AMcom.Teste.Service.Tests
