using System;
using System.Collections.Generic;
using System.Text;

namespace AMcom.Teste.Service.Interface.Mapper
{
    public interface IBaseMapper<T, TEntity>
        where T : class
        where TEntity : class
    {
        IEnumerable<TEntity> ListMapToEntity(IEnumerable<T> listModel);
        IEnumerable<T> ListMapToModel(IEnumerable<TEntity> listEntity);
        TEntity MapToEntity(T model);
        T MapToModel(TEntity model);
    }
}
