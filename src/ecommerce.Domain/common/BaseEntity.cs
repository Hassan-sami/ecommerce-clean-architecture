﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = new Guid();
    }
}
