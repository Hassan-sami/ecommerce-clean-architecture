﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>> Criteria { get;  }

        Expression<Func<T, object>> OrderBy { get;  }

        List<Expression<Func<T,object>>> Includes { get; }
        
        Expression<Func<T, object>> OrderByDesc { get;   }
        int Take { get; }
        int Skip { get; }
        bool isPagingEnabled { get; }


    }
}
