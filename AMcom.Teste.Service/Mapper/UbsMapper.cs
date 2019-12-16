using AMcom.Teste.DAL.Interface.Entity;
using AMcom.Teste.Service.Interface.DTO;
using AMcom.Teste.Service.Interface.Enum;
using AMcom.Teste.Service.Interface.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMcom.Teste.Service.Mapper
{
    public class UbsMapper : BaseMapper<UbsDTO,Ubs>, IUbsMapper
    {
        public Ubs MapToEntity(UbsDTO model) =>
            new Ubs()
            {
                NomEstab = model.Nome,
                DscEndereco = model.DscEndereco,
                DscEstrutFisicAmbiencia = (int)model.Avaliacao
            };

        public UbsDTO MapToModel(Ubs entity) =>
            new UbsDTO()
            {
                Nome = entity.NomEstab,
                DscEndereco = entity.DscEndereco,
                Avaliacao = (AvaliacaoEnum)entity.DscEstrutFisicAmbiencia
            };
    }
}
