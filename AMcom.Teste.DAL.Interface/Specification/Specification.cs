using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AMcom.Teste.DAL.Interface.Specification
{
    public abstract class Specification<T>
    {
        public static readonly Specification<T> All = new IdentitySpecification<T>();
        public abstract Expression<Func<T, bool>> ToExpression();

        public virtual bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpression().Compile();
            return predicate(entity);
        }

        
    }
}
