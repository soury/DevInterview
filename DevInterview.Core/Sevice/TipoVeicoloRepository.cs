using DevInterview.Core.Model;
using DevInterview.Providers.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.Core.Sevice
{
    public class TipoVeicoloRepository : IRepository<TipoVeicolo, string>
    {
        private DBContext context;
        public TipoVeicoloRepository(DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<TipoVeicolo> All()
        {
            return this.context.TipoVeicolo;
        }

        public bool Delete(string id)
        {
            this.context.Remove(this.context.TipoVeicolo.Where(v => v.Id.Equals(id)).FirstOrDefault());
            return this.context.SaveChanges() > 0;
        }

        public TipoVeicolo FindById(string id)
        {
            return this.context.TipoVeicolo.Where(v => v.Id.Equals(id)).FirstOrDefault();
        }

        public bool Save(TipoVeicolo item)
        {
            TipoVeicolo tipoVeicolo = this.context.TipoVeicolo.Where(v => v.Id.Equals(item.Id)).FirstOrDefault();
            if(tipoVeicolo == null)
            {
                this.context.TipoVeicolo.Add(item);
            } else
            {
                this.context.TipoVeicolo.Update(item);
            }
            return this.context.SaveChanges() > 0;
        }
    }
}
