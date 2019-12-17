using AMcom.Teste.DAL.Data;
using AMcom.Teste.DAL.Interface.Entity;
using AMcom.Teste.DAL.Interface.UnitOfWork;
using AMcom.Teste.DAL.UnitOfWork;
using AMcom.Teste.Service.Interface.DTO;
using AMcom.Teste.Service.Interface.Extension;
using AMcom.Teste.Service.Interface.Mapper;
using AMcom.Teste.Service.Interface.Service;
using AMcom.Teste.Service.Mapper;
using AMcom.Teste.Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Assert = Xunit.Assert;

namespace AMcom.Teste.Service.Tests
{
    public class UbsServiceTest
    {
        //Implemente os testes unitários para o método criado no UbsService.Faça quantos testes achar
        //pertinente para validar a sua lógica de aplicação.
        private IUnitOfWork unitOfWork;
        private DatabaseContext Context;
        private IUbsService service;
        private IUbsMapper mapper;
        
        public UbsServiceTest()
        {
            Context = InMemoryContext();
            unitOfWork = new UnitOfWork(Context);
            mapper = new UbsMapper();
            service = new UbsService(unitOfWork, mapper) ;
        }
        [Fact(DisplayName = "Insert List Ubs")]
        public void Insert_List_Ubs()
        {
            service.AddRange(GetListUbs());
            var atualInseridaUbs = service.GetUbs().ToList();

            CollectionAssert.Equals(GetListUbs(), atualInseridaUbs);
        }
        [Fact(DisplayName = "Get List Ubs")]
        public void Get_List_Ubs()
        {
            service.AddRange(GetListUbs());
            var actualUbs = service.GetUbs().ToList();

            CollectionAssert.Equals(GetListUbs(), actualUbs); 
        }

        [Fact(DisplayName = "Localiza o Ubs mais proximos")]
        public void Localiza_Ubs_Proximas()
        {
            var latitude = 9.0;
            var longitude = 35.0;
            var count = 5;
            var ubsMaisProximoExperado = new UbsDTO()
            {
                Nome = "USF ENFERMEIRO PEDRO JACINTO AREA 09",
                VlrLatitude = -9.48594331741306,
                VlrLongitude = -35.8575725555409,
                DscBairro = "CENTRO",
                DscCidade = "Rio Largo",
                DscEndereco = "R 15 DE AGOSTO",
                Avaliacao = BasicExtension.ConverterAvaliacao("Desempenho mediano ou  um pouco abaixo da média")
            };
            service.AddRange(GetListUbs());
            var listAtual = service.GetByLocationAsync(latitude, longitude, count);

            Assert.Equal(ubsMaisProximoExperado.Nome, listAtual.FirstOrDefault().Nome);


        }
        [Fact(DisplayName = "Localiza somente 5 Ubs mais proximos")]
        public void Localiza_5_Ubs_Proximas()
        {
            double latitude = -309060215950003;
            double longitude = -599864888191206;
            var count = 5;

            service.AddRange(GetListUbs());

            var listAtual = service.GetByLocationAsync(latitude, longitude, count);

            Assert.Equal(count, listAtual.Count());


        }
        [Fact(DisplayName = "Localiza somente 5 Ubs mais proximos ordenados por Avaliação")]
        public void Localiza_5_Ubs_Proximas_por_Avaliacao()
        {
            double latitude = -309060215950003;
            double longitude = -599864888191206;
            var count = 5;

            service.AddRange(GetListUbs());

            var listAtual = service.GetByLocationAsync(latitude, longitude, count);

            Assert.Equal("UNIDADE DE ATENCAO PRIMARIA SAUDE DA FAMILIA", listAtual.First().Nome);

        }
        [Fact(DisplayName = "Import Csv")]
        public void Import_Csv()
        {
            var count = 37690;
            var path = "C:/tmp/ubs.csv";
            service.ImportCsvUbs(path);
            var list = service.GetUbs();

            Assert.Equal(count, list.Count());


        }

        [Fact(DisplayName = "Coordenadas")]
        public void ConvertCoordenadas()
        {
            double latitude = -309060215950003;
            double longitude = -599864888191206;
            var primeira = BasicExtension.ToPoint(latitude, longitude);
            var segunda = BasicExtension.ToPoint(latitude, longitude);
            Assert.True(primeira.Distance(segunda) == 0);
        }
        [Fact(DisplayName = "Import Csv E Localizar Ubs mais Proxima")]
        public void GetLocaliza()

        {
            var path = "C:/tmp/ubs.csv";
            service.ImportCsvUbs(path);

            double latitude = -309060215950003;
            double longitude = -599864888191206;
            var count = 5;

            IEnumerable<UbsDTO> listAtual = service.GetByLocationAsync(latitude, longitude, count);
             Assert.Equal("UBS L 29", listAtual.First().Nome);


        }


        private List<UbsDTO> GetListUbs()
        {
            return new List<UbsDTO>()
            {
                new UbsDTO()
                {
                    Nome = "US OSWALDO DE SOUZA",
                    VlrLatitude= -10.9112370014188,
                    VlrLongitude= -37.0620775222768,
                    DscBairro = "GETULIO VARGAS",
                    DscCidade = "Aracaju",
                    DscEndereco = "TV ADALTO BOTELHO",
                    Avaliacao = BasicExtension.ConverterAvaliacao("Desempenho acima da média")
                },
                 new UbsDTO()
                {
                    Nome = "USF ENFERMEIRO PEDRO JACINTO AREA 09",
                    VlrLatitude= -9.48594331741306,
                    VlrLongitude= -35.8575725555409,
                    DscBairro = "CENTRO",
                    DscCidade = "Rio Largo",
                    DscEndereco = "R 15 DE AGOSTO",
                    Avaliacao = BasicExtension.ConverterAvaliacao("Desempenho mediano ou  um pouco abaixo da média")
                },
                  new UbsDTO()
                {
                    Nome = "UNIDADE DE ATENCAO PRIMARIA SAUDE DA FAMILIA",
                    VlrLatitude= -23896,
                    VlrLongitude= -53.41,
                    DscBairro = "CENTRO",
                    DscCidade = "Perobal",
                    DscEndereco = "RUA GUILHERME BRUXEL",
                    Avaliacao = BasicExtension.ConverterAvaliacao("Desempenho muito acima da média")
                },
                  new UbsDTO()
                {
                    Nome = "POSTO DE SAUDE DE BOM JESUS DA ALDEIA",
                    VlrLatitude= -16.447874307632,
                    VlrLongitude= -41.0098600387561,
                    DscBairro = "ALDEIA",
                    DscCidade = "Jequitinhonha",
                    DscEndereco = "RUA TEOFILO OTONI",
                    Avaliacao = BasicExtension.ConverterAvaliacao("Desempenho mediano ou  um pouco abaixo da média")
                },
                 new UbsDTO()
                {
                    Nome = "USF ENFERMEIRO PEDRO JACINTO AREA 09",
                    VlrLatitude= -6.57331109046917,
                    VlrLongitude= -35.1076054573049,
                    DscBairro = "SITIO",
                    DscCidade = "Mataraca",
                    DscEndereco = "POSTO ANCORA URUBA,RODOVIA PB N 065",
                    Avaliacao = BasicExtension.ConverterAvaliacao("Desempenho acima da média")
                },
                  new UbsDTO()
                {
                    Nome = "UNIDADE DE SAUDE DA FAMILIA ANA RAQUEL",
                    VlrLatitude= -7.03715085983256,
                    VlrLongitude= -37.2887992858876,
                    DscBairro = "JD GUANABARA",
                    DscCidade = "Patos",
                    DscEndereco = "RUA SEVERINO SOARES",
                    Avaliacao = BasicExtension.ConverterAvaliacao("Desempenho mediano ou  um pouco abaixo da média")
                }
            };
        }
        private List<UbsDTO> GetListUbsExperada()
        {
            return new List<UbsDTO>()
            {
                new UbsDTO()
                {
                    Nome = "US OSWALDO DE SOUZA",
                    VlrLatitude= -10.9112370014188,
                    VlrLongitude= -37.0620775222768,
                    DscBairro = "GETULIO VARGAS",
                    DscCidade = "Aracaju",
                    DscEndereco = "TV ADALTO BOTELHO",
                    Avaliacao = BasicExtension.ConverterAvaliacao("Desempenho acima da média")
                },
                 new UbsDTO()
                {
                    Nome = "USF ENFERMEIRO PEDRO JACINTO AREA 09",
                    VlrLatitude= -9.48594331741306,
                    VlrLongitude= -35.8575725555409,
                    DscBairro = "CENTRO",
                    DscCidade = "Rio Largo",
                    DscEndereco = "R 15 DE AGOSTO",
                    Avaliacao = BasicExtension.ConverterAvaliacao("Desempenho mediano ou  um pouco abaixo da média")
                },
                  new UbsDTO()
                {
                    Nome = "UNIDADE DE ATENCAO PRIMARIA SAUDE DA FAMILIA",
                    VlrLatitude= -23896,
                    VlrLongitude= -53.41,
                    DscBairro = "CENTRO",
                    DscCidade = "Perobal",
                    DscEndereco = "RUA GUILHERME BRUXEL",
                    Avaliacao = BasicExtension.ConverterAvaliacao("Desempenho muito acima da média")
                },
                  new UbsDTO()
                {
                    Nome = "POSTO DE SAUDE DE BOM JESUS DA ALDEIA",
                    VlrLatitude= -16.447874307632,
                    VlrLongitude= -41.0098600387561,
                    DscBairro = "ALDEIA",
                    DscCidade = "Jequitinhonha",
                    DscEndereco = "RUA TEOFILO OTONI",
                    Avaliacao = BasicExtension.ConverterAvaliacao("Desempenho mediano ou  um pouco abaixo da média")
                },
                 new UbsDTO()
                {
                    Nome = "USF ENFERMEIRO PEDRO JACINTO AREA 09",
                    VlrLatitude= -6.57331109046917,
                    VlrLongitude= -35.1076054573049,
                    DscBairro = "SITIO",
                    DscCidade = "Mataraca",
                    DscEndereco = "POSTO ANCORA URUBA,RODOVIA PB N 065",
                    Avaliacao = BasicExtension.ConverterAvaliacao("Desempenho acima da média")
                }
            }.OrderBy(ubs => ubs.Avaliacao).ToList();
        }
        private DatabaseContext InMemoryContext()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;
            var context = new DatabaseContext(options);

            return context;
        }
    }
}
