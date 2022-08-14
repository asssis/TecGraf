using System;
using System.Collections.Generic;
using System.Text;
using Tecgraf.Serial;

namespace Tecgraf.Relatorio
{
    public class DigitosRelatorios
    {
        private readonly string[] seriais = { "1818MEXXXA6789-B", "1010MEXXXA7044-C","2021BRAXXA7577-5",
                             "0909BRAXXM2077-4", "0707BRAXXM1699-9", "2020ARGXXM2730-7",
                             "1920ARGXXA6736-D", "0606ARGXXA3227-5", "1717NFKXXA4805-1", "0606MDVXXA4824-6"};

        public DigitosRelatorios()
        {
            string relatorio = string.Empty;

            relatorio += "\r\n==========DIGITO RELATORIOS=========\r\n";
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
