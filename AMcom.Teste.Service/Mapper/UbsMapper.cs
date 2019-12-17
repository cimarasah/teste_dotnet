using AMcom.Teste.DAL.Interface.Entity;
using AMcom.Teste.Service.Interface.DTO;
using AMcom.Teste.Service.Interface.Enum;
using AMcom.Teste.Service.Interface.Extension;
using AMcom.Teste.Service.Interface.Mapper;
using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Data.SqlTypes;
using System.Linq;

namespace AMcom.Teste.Service.Mapper
{
    public class UbsMapper : IUbsMapper//BaseMapper<UbsDTO,Ubs>, 
    {
        public IEnumerable<Ubs> ListMapToEntity(IEnumerable<UbsDTO> listModel)
        {
            return listModel
                    .Where(item => item != null)
                    .Select(item => MapToEntity(item)).ToList();
        }
           //listModel.Select(ubs =>  MapToEntity(ubs));

        
        public IEnumerable<UbsDTO> ListMapToModel(IEnumerable<Ubs> listEntity) =>
            listEntity.Select(MapToModel);

        public Ubs MapToEntity(UbsDTO model) =>
            new Ubs()
            {
                NomEstab = model.Nome,
                DscEndereco = model.DscEndereco,
                DscEstrutFisicAmbiencia = (int)model.Avaliacao,
                VlrLatitude = model.VlrLatitude,
                VlrLongitude = model.VlrLongitude,
                DscCidade = model.DscCidade,
                DscBairro = model.DscBairro,
                Localizacao = BasicExtension.ToPoint(model.VlrLatitude, model.VlrLongitude)
            };

        public UbsDTO MapToModel(Ubs entity) =>
            new UbsDTO()
            {
                Nome = entity.NomEstab,
                DscEndereco = entity.DscEndereco,
                Avaliacao = (AvaliacaoEnum)entity.DscEstrutFisicAmbiencia,
                VlrLatitude = entity.VlrLatitude,
                VlrLongitude = entity.VlrLongitude,
                DscCidade = entity.DscCidade,
                DscBairro = entity.DscBairro
            }; 
    }
}
