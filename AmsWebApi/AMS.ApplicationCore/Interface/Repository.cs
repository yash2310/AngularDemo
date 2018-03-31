using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ApplicationCore.Interface
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(object Id);
        string Delete(object Id);
        string Update(T obj);
        string Insert(T obj);
        string Save();
    }
}