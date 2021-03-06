﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiX.Data.XInfrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBaseAsync<T> getRepository<T>() where T : class; 
        void CommitAsync();
        void Commit();
       
    }

}
