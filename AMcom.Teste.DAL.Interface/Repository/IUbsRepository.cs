using AMcom.Teste.DAL.Interface.Entity;
using AMcom.Teste.DAL.Interface.Specification;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AMcom.Teste.DAL.Interface.Repository
{
    public interface IUbsRepository : IDisposable
    {
        IEnumerable<Ubs> GetUbs();
        Ubs GetUbsByID(int Id);
        void Add(Ubs ubs);
        void AddRange(IEnumerable<Ubs> ubsList);
        void Delete(int Id);
        IEnumerable<Ubs> GetAsyncSpecification(Specification<Ubs> specification, int page, int size, bool descending, Expression<Func<Ubs, object>> orderby);
    }
}
