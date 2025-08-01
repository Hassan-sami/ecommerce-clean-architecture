﻿using ecommerce.Domain.common;
using ecommerce.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infra.Repos
{
    public class SpecificationEvaluator<T> where T : BaseEntity 
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;

            // modify the IQueryable using the specification's criteria expression
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            // Includes all expression-based includes
            query = specification.Includes.Aggregate(query,
                                    (current, include) => current.Include(include));

            //// Include any string-based include statements
            //query = specification.IncludeStrings.Aggregate(query,
            //                        (current, include) => current.Include(include));

            // Apply ordering if expressions are set
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDesc != null)
            {
                query = query.OrderByDescending(specification.OrderByDesc);
            }

            //Apply paging if enabled
            if (specification.isPagingEnabled)
                {
                    query = query.Skip(specification.Skip)
                                 .Take(specification.Take);
                }
            return query;
        }
    }
}
