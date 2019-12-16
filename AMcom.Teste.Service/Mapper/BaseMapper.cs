using AMcom.Teste.DAL.Interface.Entity;
using AMcom.Teste.Service.Interface.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMcom.Teste.Service.Mapper
{
    public abstract partial class BaseMapper<T, TEntity> : IBaseMapper<T, TEntity>
        where T : class
        where TEntity : class
    {
        public IEnumerable<TEntity> ListMapToEntity(IEnumerable<T> listModel) =>
           listModel.Select(MapToEntity);
        public IEnumerable<T> ListMapToModel(IEnumerable<TEntity> listEntity) =>
            listEntity.Select(MapToModel);

        public virtual TEntity MapToEntity(T model) => null;
        
        public virtual T MapToModel(TEntity model) => null;
    }
}
