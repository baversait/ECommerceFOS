﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Model.Models;

namespace Data.Repositories
{
    public class ColorRepository : RepositoryBase<Color>, IColorRepository 
    {
        public ColorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IColorRepository : IRepository<Color>
    {

    }
}
