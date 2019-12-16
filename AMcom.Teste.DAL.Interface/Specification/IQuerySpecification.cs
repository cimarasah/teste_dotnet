using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AMcom.Teste.DAL.Interface.Specification
{
    public interface IQuerySpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        Expression<Func<T, object>> OrderBy { get; }
        bool OrderDescending { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
        bool IsSatisfiedBy(T o);
    }
}