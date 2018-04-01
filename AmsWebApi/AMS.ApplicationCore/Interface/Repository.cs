using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ApplicationCore.Interface
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAllById(object Id);
        T GetById(object Id);
        bool Delete(object Id);
        bool Update(T obj);
        bool Insert(T obj);
    }
}