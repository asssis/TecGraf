using System;
using System.Collections.Generic;
using System.Text;
using Tecgraf.Serial;

namespace Tecgraf.Relatorio
{
    public class GerarDigitosVerificador
    {
        private readonly string[] seriais = { "1313MEXXXA7747", "0102MEXXXC7090",
                                              "0101BRAXXC7905", "0809BRAXXC0563",
                                              "2020BRAXXM7671", "0203ARGXXM2982",
                                              "1415ARGXXA2794", "1819ARGXXM9860",
                                              "2020PHLXXC9800", "0607MWIXXA9994"};

        public GerarDigitosVerificador()
        {

            string relatorio = string.Empty;
            relatorio += "\r\n==========DIGITO GERAR VERIFICADORES=========\r\n";
            relatorio += $"|     Serial     ";
            relatorio += $"| AnoF ";
            relatorio += $"| AnoM ";
            relatorio += $"|    Tipo   ";
            relatorio += $"| Pais".PadRight(23);
            relatorio += $"| Seq ";
            relatorio += $"| D Ver |";
            relatorio += $"| Valido |";


            foreach (var item in seriais)
            {
                var obj = new Resolve().getSerial(item);
                int center = (20 + obj.Pais.Length) / 2;
                string linha = string.Empty;
                linha += $"| {obj.Serial} | ";
                linha += $"{obj.AnoFabricacao} | ";
                linha += $"{obj.AnoModelo} | ";
                linha += $"{obj.Tipo.ToString()} | ";
                linha += $"{obj.Pais.PadLeft(center, ' ').PadRight(20)} | ";
                linha += $"{obj.Sequencial} |";
                linha += $"  {obj.DigitoVerificador}   |";
                linha += $"  {obj.Valido }   |";
                relatorio += $"\r\n{"".PadLeft(linha.Length, '=')}\r\n{linha}";
            }
            Console.WriteLine(relatorio);
        }
    }
}
