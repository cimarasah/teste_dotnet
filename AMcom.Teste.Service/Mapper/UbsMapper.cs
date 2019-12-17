using AMcom.Teste.DAL.Interface.Entity;
using AMcom.Teste.Service.Interface.DTO;
using AMcom.Teste.Service.Interface.Enum;
using AMcom.Teste.Service.Interface.Extension;
using AMcom.Teste.Service.Interface.Mapper;

namespace AMcom.Teste.Service.Mapper
{
    public class UbsMapper : BaseMapper<UbsDTO,Ubs>, IUbsMapper
    {
        public override Ubs MapToEntity(UbsDTO model) =>
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

        public override UbsDTO MapToModel(Ubs entity) =>
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
