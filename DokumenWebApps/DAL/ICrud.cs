using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DokumenWebApps.DAL
{
    //crud
    public interface ICrud<T>
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        void Create(T obj);
        void Update(T obj);
        void Delete(string id);
    }
}
