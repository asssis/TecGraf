using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tecgraf.Serial
{
    public class Funcoes
    {
        public static string getDigitoVerificador(string serial)
        {
            serial = serial.Split("-")[0];
            //FAZENDO O CALCULO COM AGREGATE AO INVES DO FOREACH
            int total = serial.Aggregate(
                          seed: 0,
                          func: (acc, x) => acc + Convert.ToInt32(x));

            //TIRANDO RESTO
            int resto = total % 16;

            //CONVERTENTO PARA HEXADECIMAL
            return resto.ToString("X");
        }
        public static string getAnoFabricacao(string serial)
        {
            return $"20{serial.Substring(0,2)}";
        }
        public static string getAnoModelo(string serial)
        { 
            return $"20{serial.Substring(2, 2)}";
        }

        private static int sequencial = 100;
        public static string getSequencial()
        {
            sequencial++;
            return sequencial.ToString();
        }

        public static string getPaisNome(string serial)
        { 
            return serial.Substring(4, 3);
        }

        public static string getTipo(string serial)
        {
            return serial.Substring(7, 1);
        }
        public static string getSequencial(string serial)
        {
            string sequencial = serial.Substring(10, serial.Length-10);
            return sequencial.Split("-")[0];
        }

        public static string getCheckValido(string serial)
        {
            string digito = getDigitoVerificador(serial);
            string[] valor = serial.Split("-");
            if (valor.Length < 2)
                return "Sem Digit";
            else if (valor[1] == digito)
                return "Valido  ";
            else
                return "Invalido";

        }
    }
}
