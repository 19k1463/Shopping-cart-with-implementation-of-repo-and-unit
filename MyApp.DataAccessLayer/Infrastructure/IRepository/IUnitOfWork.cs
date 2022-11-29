using MyApp.DataAccessLayer.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.DataAccessLayer.Infrastructure.IRepository;

namespace MyApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface IUnitOfWork 
    {
        ICategoryRepository Category { get;  }
        void Save();
    }

   
}
