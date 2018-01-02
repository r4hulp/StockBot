using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEBot.Service.Utils
{
    public static class Converters
    {
        public static string JsObjectConverter(string buffer)
        {
            buffer = buffer.Replace("true", "True");
            buffer = buffer.Replace("false", "False");
            buffer = buffer.Replace("none", "None");
            buffer = buffer.Replace("NaN", "\"NaN\"");
            return buffer;
        }
    }
}
