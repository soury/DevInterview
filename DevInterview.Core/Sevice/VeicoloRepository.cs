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
    public class VeicoloRepository : IRepository<Veicolo, int>
    {
        private DBContext context;
        public VeicoloRepository(DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Veicolo> All()
        {
            return this.context.Veicolo;
        }

        public bool Delete(int id)
        {
            this.context.Remove(this.context.Veicolo.Where(v => v.Id == id).FirstOrDefault());
            return this.context.SaveChanges() > 0;
        }

        public Veicolo FindById(int id)
        {
            return this.context.Veicolo.Include(v => v.IdAlimentazioneNavigation).Where(v => v.Id == id).FirstOrDefault();
        }

        public bool Save(Veicolo item)
        {
            Veicolo veicolo = this.context.Veicolo.Where(v => v.Id == item.Id).FirstOrDefault();
            if(veicolo == null)
            {
                this.context.Veicolo.Add(item);
            } else
            {
                this.context.Veicolo.Update(item);
            }
            return this.context.SaveChanges() > 0;
        }
    }
}
