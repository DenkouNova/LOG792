using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageExtract
{
    class StringTools
    {
        public static string TraceString(int i)
        {
            return i.ToString();
        }

        public static string TraceString(int? i)
        {
            return (i == null ? "(null)" : i.ToString());
        }

        public static string TraceString(float f)
        {
            return f.ToString();
        }

        public static string TraceString(float? f)
        {
            return (f == null ? "(null)" : f.ToString());
        }

        public static string TraceString(string s)
        {
            return "'" + (s == null ? "(null)" : s) + "'";
        }


    }
}
