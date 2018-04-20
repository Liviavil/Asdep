﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asdep.Common.DAO.ExtraDao
{
    public static class Common
    {
        public static string ToCustomString(this List<T_ErroriIODao> errori)
        {
            string result = "";

            foreach (T_ErroriIODao e in errori)
            {
                result += e.CodTipoErrore + ",";
            }
            return result;
        }
    }

    public static class PropertyCopier<TParent, TChild>
        where TParent : class
        where TChild : class
    {
        public static void Copy(TParent parent, TChild child)
        {
            var parentProperties = parent.GetType().GetProperties();
            var childProperties = child.GetType().GetProperties();
            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                    {
                        childProperty.SetValue(child, parentProperty.GetValue(parent)); break;
                    }
                }
            }
        }
    }
}
