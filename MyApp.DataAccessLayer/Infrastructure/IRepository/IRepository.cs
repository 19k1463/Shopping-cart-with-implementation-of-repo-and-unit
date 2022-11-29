using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface IRepository<T> where T : class 
        /*im making here generic interface thou study about this*/
    {
        IEnumerable<T> GetAll();  // do study this ienumerable function//
        T GetT(Expression<Func <T,bool>> predicate); // do study this lamba expression //
        void Add(T entity);  // what here is the entity //
        void Delete(T entity); //same goes for here//
        void DeleteRange(IEnumerable<T>  entity);  
    }
}
