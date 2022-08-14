using System;
using System.Collections.Generic;
using System.Text;

namespace Tecgraf.Model
{
    public enum TipoAutomovel
    {
        Automovel=0, Motocicleta=1, Caminhao=2
    }
    public class SerialNumber
    {
        public string Serial { get; set; }
        public string AnoFabricacao { get; set; }
        public string AnoModelo { get; set; }
        public string Pais
        {
            get
            {
                return Dpara.Pais.getInstancia().getPais(SlgPais);
            }
        }
        public string SlgPais { get; set; }
        public string Sequencial { get; set; }
        public string DigitoVerificador { get; set; }

        public TipoAutomovel Tipo { set; get; }
        public string GetTipoStr 
        {
            get
            {
                switch (Tipo)
                {
                    case TipoAutomovel.Automovel:
                        return "A";
                    case TipoAutomovel.Motocicleta:
                        return "M";
                    case TipoAutomovel.Caminhao:
                        return "C";
                    default:
                        return " ";
                }
            }
        }

        public string SetTipo
        {
            set
            {
                switch (value)
                {
                    case "A":
                        Tipo = TipoAutomovel.Automovel;
                        break;
                    case "M":
                        Tipo = TipoAutomovel.Motocicleta;
                        break;
                    case "C":
                        Tipo = TipoAutomovel.Caminhao;
                        break;
                }
            }
        }

        public string Valido {get;  set; }

        public string GetDesAutomovel()
        {
            return this.Tipo.ToString();
        }
    }

}
