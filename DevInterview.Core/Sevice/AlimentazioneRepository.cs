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
    public class AlimentazioneRepository : IRepository<Alimentazione, int>
    {
        private DBContext context;
        public AlimentazioneRepository(DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Alimentazione> All()
        {
            return this.context.Alimentazione;
        }

        public bool Delete(int id)
        {
            this.context.Remove(this.context.Alimentazione.Where(v => v.Id == id).FirstOrDefault());
            return this.context.SaveChanges() > 0;
        }

        public Alimentazione FindById(int id)
        {
            return this.context.Alimentazione.Where(v => v.Id == id).FirstOrDefault();
        }

        public bool Save(Alimentazione item)
        {
            Alimentazione marca = this.context.Alimentazione.Where(v => v.Id == item.Id).FirstOrDefault();
            if(marca == null)
            {
                this.context.Alimentazione.Add(item);
            } else
            {
                this.context.Alimentazione.Update(item);
            }
            return this.context.SaveChanges() > 0;
        }
    }
}
