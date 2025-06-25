using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace Z1
{
    public static class Reflekcja
    {
        public static string OdczytajPolaPrywatne(RachunekFirmowy obj)
        {
            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pola prywatne klasy {type.Name}:");

            if (fields.Length == 0)
            {
                sb.AppendLine("Brak pól prywatnych.");
            }
            else
            {
                foreach (FieldInfo field in fields)
                {
                    sb.AppendLine($"- Nazwa: {field.Name}, Wartość: {field.GetValue(obj)}");
                }
            }
            return sb.ToString();

        }
    }
}
