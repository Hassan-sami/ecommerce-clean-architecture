﻿using ecommerce.Domain.common;
using ecommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Specifications
{

    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        protected BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
            Includes = new List<Expression<Func<T, object>>>();
        }

        public Expression<Func<T, bool>>? Criteria { get; private set; }
        public Expression<Func<T, object>>? OrderBy { get; private set; }
        public List<Expression<Func<T, object>>>? Includes { get; private set; }
        public Expression<Func<T, object>>? OrderByDesc { get; private set; }
        
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool isPagingEnabled { get; private set; } = false;


        protected virtual void AddInclude(Expression<Func<T, object>> includeString)
        {
            Includes?.Add(includeString);
        }
        
        protected virtual void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        protected virtual void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDesc = orderByDescendingExpression;
        }
        protected virtual void ApplyPaging(int skip, int take)
        {
            if(skip < 0)
                Skip = 0;
            if(take <= 0)
                Take = 10;
            Skip = skip;
            Take = take;
            isPagingEnabled = true;
        }
    }
}
