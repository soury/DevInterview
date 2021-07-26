using DevInterview.Providers.Common.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace DevInterview.Core.Model
{
    public partial class Provincia : IStoreable<int>, IComparable<int>
    {
        public Provincia()
        {
            Veicolo = new HashSet<Veicolo>();
        }

        public int Id { get; set; }
        public string Decrizione { get; set; }

        public virtual ICollection<Veicolo> Veicolo { get; set; }

        public int CompareTo(int other)
        {
            return Id.CompareTo(other);
        }
    }
}
