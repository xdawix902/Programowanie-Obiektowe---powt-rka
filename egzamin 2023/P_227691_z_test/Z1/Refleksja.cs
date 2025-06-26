using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Z1
{
    public static class Refleksja
    {
        public static string OdczytajPolePrywatne(RachunekFirmowy rachunekFirmowy)
        {
            var type = rachunekFirmowy.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo e in fields)
            {
                sb.Append(e);
            }
            return sb.ToString();
        }
    }
}
