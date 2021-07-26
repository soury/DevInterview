using DevInterview.Providers.Common.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace DevInterview.Core.Model
{
    public partial class Veicolo : IStoreable<int>, IComparable<int>
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
        public decimal EmissioniCo2 { get; set; }
        public decimal MassaComplessiva { get; set; }

        public virtual Alimentazione IdAlimentazioneNavigation { get; set; }
        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual Provincia IdProvinciaNavigation { get; set; }
        public virtual Uso IdUsoNavigation { get; set; }
        public virtual TipoVeicolo TipoVeicoloNavigation { get; set; }

        public int CompareTo(int id)
        {
            return Id.CompareTo(id);
        }
    }
}
