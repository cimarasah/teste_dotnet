using AMcom.Teste.DAL.Data;
using AMcom.Teste.DAL.Interface.Entity;
using AMcom.Teste.DAL.Interface.Repository;
using AMcom.Teste.DAL.Interface.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AMcom.Teste.DAL.Repository
{
    public class UbsRepository : IUbsRepository
    {
        // Implemente um método que retorne uma lista/coleção de objetos do tipo Ubs.
        // Caso necessário, crie um parâmetro para filtrar os objetos dessa coleção se a lógica não for 
        // implementada na camada de serviços.
        private readonly DatabaseContext _context;

        public UbsRepository(DatabaseContext ubsContext)
        {
            _context = ubsContext;
        }

        public IEnumerable<Ubs> GetUbs()
        {
            return _context.Ubs;
        }

        public Ubs GetUbsByID(int ubsID)
        {
            return _context.Ubs.FirstOrDefault(x => x.Id == ubsID);
        }

        public void Add(Ubs ubs)
        {
            _context.Ubs.Add(ubs);
            _context.SaveChanges();
        }
        public void AddRange(IEnumerable<Ubs> ubsList)
        {
            _context.Ubs.AddRange(ubsList);
            _context.SaveChanges();
        }
        public void Delete(int ubsId)
        {
            var ubs = _context.Ubs.FirstOrDefault(x => x.Id == ubsId);
            _context.Ubs.Remove(ubs);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
        public IEnumerable<Ubs> GetAsyncSpecification(Specification<Ubs> specification, int page, int size, bool descending, Expression<Func<Ubs, object>> orderby)
        {
            var query = _context
                        .Set<Ubs>()
                        .Where(specification.ToExpression())
                        .Skip((page - 1) * size)
                        .Take(size);

            if (descending)
                query = query.OrderByDescending(orderby);
            else
                query = query.OrderBy(orderby);

            return query.ToList();
        }
    }
}
