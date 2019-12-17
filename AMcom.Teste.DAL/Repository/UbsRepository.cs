using AMcom.Teste.DAL.Data;
using AMcom.Teste.DAL.Interface.Entity;
using AMcom.Teste.DAL.Interface.Repository;
using GeoAPI.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public IEnumerable<Ubs> GetLocalizaUbsAvaliacao(IPoint localizacao, int size)
        {
            
            return _context.Ubs
                .OrderBy(ubs => ubs.Localizacao.Distance(localizacao))
                .Select(ubs => ubs)
                .Take(size)
                .OrderBy(ubs => ubs.DscEstrutFisicAmbiencia)
                .ToList();

        }
        public IEnumerable<double> Getdistancia(IPoint localizacao)
        {

            return _context.Ubs
                .OrderBy(ubs => ubs.Localizacao.Distance(localizacao))
                .Select(ubs => ubs.Localizacao.Distance(localizacao))
                // .Take(size)
                //.OrderBy(ubs => ubs.DscEstrutFisicAmbiencia)
                .ToList();

        }
    }
}
