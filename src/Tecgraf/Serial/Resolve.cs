using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tecgraf.Model;

namespace Tecgraf.Serial
{
    public class Resolve
    { 
        public SerialNumber getSerial(SerialNumber serial)
        {
            string serial_number = string.Empty;

            if (serial.AnoFabricacao == null || serial.AnoFabricacao.Length != 4)
                return null;
            if (serial.AnoModelo == null || serial.AnoModelo.Length != 4)
                return null; 
            if (serial.SlgPais == null || serial.SlgPais.Length != 3)
                return null; 

            serial_number += serial.AnoFabricacao.Substring(2, 2);
            serial_number += serial.AnoModelo.Substring(2, 2);
            serial_number += serial.SlgPais;
            serial_number += "XX";
            serial_number += Funcoes.getSequencial();
            serial_number += "-";
            serial_number += serial.GetTipoStr;
            return getSerial(serial_number);
        } 

        public SerialNumber getSerial(string serial)
        {
            var serialNumber = new SerialNumber();
            serialNumber.AnoFabricacao = Funcoes.getAnoFabricacao(serial);
            serialNumber.Serial = serial;
            serialNumber.AnoModelo = Funcoes.getAnoModelo(serial);
            serialNumber.SlgPais = Funcoes.getPaisNome(serial);
            serialNumber.SetTipo = Funcoes.getTipo(serial);
            serialNumber.Sequencial = Funcoes.getSequencial(serial);
            serialNumber.DigitoVerificador = Funcoes.getDigitoVerificador(serial);
            serialNumber.Valido = "Valido  ";
            return serialNumber;
        }

        public SerialNumber checkSerial(string serial)
        {
            string[] digito_verificador = serial.Split("-");
            var serialNumber = new SerialNumber();
            serialNumber.Serial = serial;
            serialNumber.AnoFabricacao = Funcoes.getAnoFabricacao(serial);
            serialNumber.AnoModelo = Funcoes.getAnoModelo(serial);
            serialNumber.SlgPais = Funcoes.getPaisNome(serial);
            serialNumber.SetTipo = Funcoes.getTipo(serial);
            serialNumber.Sequencial = Funcoes.getSequencial(serial);
            if(digito_verificador.Length > 1)
                serialNumber.DigitoVerificador = digito_verificador[1];
            serialNumber.Valido = Funcoes.getCheckValido(serial);
            return serialNumber;
        }
        public bool checkDigitoVerificador(string serial)
        {
            string[] serial_digito = serial.Split("-");
            string resultado = Funcoes.getDigitoVerificador(serial);
            if (serial_digito.Length <= 1)
                return false;
            else
                return serial_digito[1] == resultado;
        }
    }
}
