using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AMcom.Teste.DAL.Interface.Specification
{
    internal sealed class IdentitySpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> ToExpression() => x => true;
    }
}
