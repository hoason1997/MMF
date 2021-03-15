using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFF.Data.BaseDBContext
{
    public abstract class BaseDbContext : DbContext
    {
        public BaseDbContext(string options) : base(options)
        {

        }

    }
}
