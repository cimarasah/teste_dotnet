using AMcom.Teste.DAL.Data;
using AMcom.Teste.DAL.Interface.Repository;
using AMcom.Teste.DAL.Interface.UnitOfWork;
using AMcom.Teste.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMcom.Teste.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUbsRepository _ubs;

        private readonly DatabaseContext _ubsContext;

        public UnitOfWork(DatabaseContext ubsContext)
        {
            _ubsContext = ubsContext;
        }

        public IUbsRepository Ubs
        {
            get
            {
                if (_ubs == null)
                {
                    _ubs = new UbsRepository(_ubsContext);
                }
                return _ubs;
            }
        }

        public void Commit()
        {
            _ubsContext.SaveChanges();
        }
    }
}
