﻿using ImovelWeb.DDD.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImovelWeb.Repository
{
    public class RepositoryUsuario:RepositoryBase<T>,IUsuario
    {
        public RepositoryUsuario():base(){ }
    }
}
