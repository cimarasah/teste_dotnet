using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AMcom.Teste.DAL.Interface.Specification
{
    public abstract class QuerySpecification<T> : Specification<T>, IQuerySpecification<T>
    {
        public QuerySpecification(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> orderBy = null, bool orderDescending = false)
        {
            Criteria = criteria;
            OrderBy = orderBy;
            OrderDescending = orderDescending;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public Expression<Func<T, object>> OrderBy { get; }

        public bool OrderDescending { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public List<string> IncludeStrings { get; } = new List<string>();

        protected virtual void AddInclude(Expression<Func<T, object>> include) =>
            Includes.Add(include);

        protected virtual void AddInclude(string includeString) =>
            IncludeStrings.Add(includeString);

        public override Expression<Func<T, bool>> ToExpression()
        {
            return Criteria;
        }
    }
}
