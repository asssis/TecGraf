using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using Tecgraf.Dpara;
using Tecgraf.Relatorio;
using Tecgraf.Serial;

namespace Tecgraf
{ 
    class Program
    {

        static void Main(string[] args)
        { 
            string serial = "1314MEXXXA7989-3";
            new Resolve().getSerial(serial); 
            var teeste = new Resolve().checkDigitoVerificador(serial);
            new DigitosVerificadores();
            new DigitosRelatorios();
            new GerarDigitosVerificador();
            Console.ReadKey();

        }

    }
}
