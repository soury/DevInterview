using DevInterview.Providers.Common.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace DevInterview.Core.Model
{
    public partial class TipoVeicolo : IStoreable<string>, IComparable<string>
    {
        public TipoVeicolo()
        {
            Veicolo = new HashSet<Veicolo>();
        }

        public string Id { get; set; }
        public string Descrizione { get; set; }
        public virtual ICollection<Veicolo> Veicolo { get; set; }

        public int CompareTo(string other)
        {
            return Id.CompareTo(other);
        }
    }
}
