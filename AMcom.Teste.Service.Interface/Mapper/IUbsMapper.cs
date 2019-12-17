using AMcom.Teste.DAL.Interface.Entity;
using AMcom.Teste.Service.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMcom.Teste.Service.Interface.Mapper
{
    public interface IUbsMapper //: IBaseMapper<UbsDTO, Ubs>
    {
        IEnumerable<Ubs> ListMapToEntity(IEnumerable<UbsDTO> listModel);
        IEnumerable<UbsDTO> ListMapToModel(IEnumerable<Ubs> listEntity);
        Ubs MapToEntity(UbsDTO model);
        UbsDTO MapToModel(Ubs entity);
    }
}
