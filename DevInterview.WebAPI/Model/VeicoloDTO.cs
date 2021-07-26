using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevInterview.WebAPI.Model
{
    public class VeicoloDTO
    {
        public int Id { get; set; }
        public string TipoVeicolo { get; set; }
        public int IdUso { get; set; }
        public string Destinazione { get; set; }
        public int IdProvincia { get; set; }
        public int IdMarca { get; set; }
        public decimal Cilindrata { get; set; }
        public int IdAlimentazione { get; set; }
        public decimal Kw { get; set; }
        public string DataImmatricolazione { get; set; }
        public string ClasseEuro { get; set; }

    }
}
