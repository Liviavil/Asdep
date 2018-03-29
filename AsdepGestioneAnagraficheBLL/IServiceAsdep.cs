using AsdepGestioneAnagraficheBLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsdepGestioneAnagraficheBLL
{
    public interface IServiceAsdep<T> where T : class 
    {
        int AddOne(T obj);
        int AddMany(List<T> obj);
        List<T> GetAll();
    }
}

