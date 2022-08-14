using System;
using System.Collections.Generic;
using System.Text;
using Tecgraf.Model;
using Tecgraf.Serial;

namespace Tecgraf.Relatorio
{
    public class DigitosVerificadores
    {
        private readonly string[] seriais ={"1313MEXXXA7989-4", "0606MEXXXA3820-4",
                                            "0708BRAXXC4014-3", "0606BRAXXA6466-8",
                                            "0909BRAXXC3262-8", "1414ARGXXA5834-9",
                                            "0202ARGXXC2614-E", "1717ARGXXA9193-C",
                                            "1415PAKXXM0980-5", "1213ASMXXC8348-2" };

        public DigitosVerificadores()
        {

            string relatorio = string.Empty;
            relatorio += "\r\n==========DIGITO VERIFICADORES=========\r\n";
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
                var obj = new Resolve().checkSerial(item);
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
