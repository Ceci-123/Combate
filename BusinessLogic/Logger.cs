using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Logger
    {
        string ruta;
        public Logger(string ruta)
        {
            this.ruta = ruta;
        }
        public void GuardarLog(string texto)
        {
            using(StreamWriter writer = new StreamWriter(ruta, true))
            {
                writer.WriteLine(texto);
            }
        }
    }
}
