using AMcom.Teste.DAL.Interface.UnitOfWork;
using AMcom.Teste.Service.Interface.DTO;
using AMcom.Teste.Service.Interface.Exceptions;
using AMcom.Teste.Service.Interface.Extension;
using AMcom.Teste.Service.Interface.Mapper;
using AMcom.Teste.Service.Interface.Service;
using System;
using System.Collections.Generic;
using System.IO;

namespace AMcom.Teste.Service.Service
{
    public class UbsService : IUbsService
    {
        // Implemente um método que retorne as 5 UBSs mais próximas de um ponto (latitude e longitude) que devem 
        // ser passados como parâmetro para o método e retorne uma lista/coleção de objetos do tipo UbsDTO.
        // Esta lista deve estar ordenada pela avaliação (da melhor para a pior) de acordo com os dados que constam
        // no objeto retornado pela camada de acesso a dados (DAL).

        private readonly IUnitOfWork unitOfWork;
        private readonly IUbsMapper mapper;

        public UbsService(IUnitOfWork unitOfWork,
            IUbsMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void Add(UbsDTO ubs) =>
            unitOfWork.Ubs.Add(mapper.MapToEntity(ubs));
        

        public void AddRange(IEnumerable<UbsDTO> ubsList) =>
            unitOfWork.Ubs.AddRange(mapper.ListMapToEntity(ubsList));

        public void Delete(int Id) =>
            unitOfWork.Ubs.Delete(Id);

        public IEnumerable<UbsDTO> GetUbs() =>
            mapper.ListMapToModel(unitOfWork.Ubs.GetUbs());

        public UbsDTO GetUbsByID(int Id) =>
            mapper.MapToModel(unitOfWork.Ubs.GetUbsByID(Id));

        public IEnumerable<UbsDTO> GetByLocationAsync(double latitude, double longitude, int count)
        {

            var list = unitOfWork.Ubs
                        .GetLocalizaUbsAvaliacao(BasicExtension.ToPoint(latitude, longitude), 5);
            return mapper.ListMapToModel(list);
        }
        public IEnumerable<double> GetDistancia(double latitude, double longitude)
        {

            var list = unitOfWork.Ubs
                        .Getdistancia(BasicExtension.ToPoint(latitude, longitude));
            return list;
        }

        public bool ImportCsvUbs(string path)
        {
            try
            {
                var list = BasicExtension.ImportCsvToUbs(@path);
                unitOfWork.Ubs.AddRange(mapper.ListMapToEntity(list));
                
            }
            catch (IOException ioEx)
            {
                throw new BusinessException(ExceptionMessages.ImportacaoArquivo);
            }
            return true;
        }
    }
}
