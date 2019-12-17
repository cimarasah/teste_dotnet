using AMcom.Teste.DAL.Interface.Entity;
using GeoAPI.Geometries;
using System;
using System.Collections.Generic;

namespace AMcom.Teste.DAL.Interface.Repository
{
    public interface IUbsRepository : IDisposable
    {
        IEnumerable<Ubs> GetUbs();
        Ubs GetUbsByID(int Id);
        void Add(Ubs ubs);
        void AddRange(IEnumerable<Ubs> ubsList);
        void Delete(int Id);
        IEnumerable<Ubs> GetLocalizaUbsAvaliacao(IPoint localizacao, int size);
        IEnumerable<double> Getdistancia(IPoint localizacao);
    }
}
