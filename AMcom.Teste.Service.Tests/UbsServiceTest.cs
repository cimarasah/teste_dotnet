using AMcom.Teste.DAL.Data;
using AMcom.Teste.DAL.Interface.Entity;
using AMcom.Teste.DAL.Interface.UnitOfWork;
using AMcom.Teste.DAL.UnitOfWork;
using AMcom.Teste.Service.Interface.Extension;
using AMcom.Teste.Service.Interface.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
        private List<Ubs> expectedUbs;
        private Mock<IUbsService> service;
        public UbsServiceTest()
        {
            Context = InMemoryContext();
            unitOfWork = new UnitOfWork(Context);
            expectedUbs = GetListUbs().ToList();
            this.service = new Mock<IUbsService>() ;
        }
        [Fact(DisplayName = "Insert List Ubs")]
        public void UnitOfWork_Insert_List_Ubs()
        {
            

            unitOfWork.Ubs.AddRange(expectedUbs);
            unitOfWork.Commit();

            var actualUbs = unitOfWork.Ubs.GetUbs().ToList();

            CollectionAssert.AreEquivalent(expectedUbs, actualUbs); 
        }

        [Fact(DisplayName = "Localiza 5 Ubs mais proximas")]
        public void Localiza_Ubs_Proximas()
        {
            var latitude = 9.0;
            var longitude = 35.0;
            var count = 5;
            var ubsMaisProximo = new Ubs()
            {
                NomEstab = "USF ENFERMEIRO PEDRO JACINTO AREA 09",
                VlrLatitude = -9.48594331741306,
                VlrLongitude = -35.8575725555409,
                Location = BasicExtension.ToPoint(-9.48594331741306, -35.8575725555409),
                DscEndereco = "R 15 DE AGOSTO",
                DscEstrutFisicAmbiencia = (int)BasicExtension.ConverterAvaliacao("Desempenho mediano ou  um pouco abaixo da média")
            };


            var listLoc = service.Setup(x => 
            x.GetByLocationAsync(latitude, longitude, count).ElementAt(0).Nome).Returns(ubsMaisProximo.NomEstab)
        }
        private List<Ubs> GetListUbs()
        {
            return new List<Ubs>()
            {
                new Ubs()
                {
                    NomEstab = "US OSWALDO DE SOUZA",
                    VlrLatitude= -10.9112370014188,
                    VlrLongitude= -37.0620775222768,
                    Location = BasicExtension.ToPoint(-10.9112370014188,-37.0620775222768),
                    DscEndereco = "TV ADALTO BOTELHO",
                    DscEstrutFisicAmbiencia = (int)BasicExtension.ConverterAvaliacao("Desempenho acima da média")
                },
                 new Ubs()
                {
                    NomEstab = "USF ENFERMEIRO PEDRO JACINTO AREA 09",
                    VlrLatitude= -9.48594331741306,
                    VlrLongitude= -35.8575725555409,
                    Location = BasicExtension.ToPoint(-9.48594331741306,-35.8575725555409),
                    DscEndereco = "R 15 DE AGOSTO",
                    DscEstrutFisicAmbiencia = (int)BasicExtension.ConverterAvaliacao("Desempenho mediano ou  um pouco abaixo da média")
                },
                  new Ubs()
                {
                    NomEstab = "UNIDADE DE ATENCAO PRIMARIA SAUDE DA FAMILIA",
                    VlrLatitude= -23896,
                    VlrLongitude= -53.41,
                    Location = BasicExtension.ToPoint(-23896,-53.41),
                    DscEndereco = "RUA GUILHERME BRUXEL",
                    DscEstrutFisicAmbiencia = (int)BasicExtension.ConverterAvaliacao("Desempenho muito acima da média")
                }
            };
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
