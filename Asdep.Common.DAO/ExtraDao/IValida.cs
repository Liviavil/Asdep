using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asdep.Common.DAO.ExtraDao
{
    public interface IValida
    {
        T_ErroriIODao Esegui(string valore);
    }
}
