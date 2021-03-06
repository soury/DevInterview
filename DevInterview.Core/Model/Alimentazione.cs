using DevInterview.Providers.Common.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace DevInterview.Core.Model
{
    public partial class Alimentazione : IStoreable<int>, IComparable<int>
    {
        public Alimentazione()
        {
            Veicolo = new HashSet<Veicolo>();
        }

        public int Id { get; set; }
        public string Descrizione { get; set; }

        public virtual ICollection<Veicolo> Veicolo { get; set; }

        public int CompareTo(int other)
        {
            return Id.CompareTo(other);
        }
    }
}
