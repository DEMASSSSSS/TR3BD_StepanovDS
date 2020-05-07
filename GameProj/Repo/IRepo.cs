using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProj.Models
{
    public interface IRepo<T>
    {
        int Add(T entity);
        int AddRange(IList<T> entities);
        int Save(T entity);
        int Delete(T entity);
        T GetOne(int? id);
        List<T> GetAll();
        List<T> ExecuteQuery(string sql);
        List<T> ExecuteQuery(string sql, object[] sqlParametersObjects);
    }
}
