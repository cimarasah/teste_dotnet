using AMcom.Teste.DAL.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMcom.Teste.DAL.Interface.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUbsRepository Ubs { get; }
        void Commit();
    }
}
