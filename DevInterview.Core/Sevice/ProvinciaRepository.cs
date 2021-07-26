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
    public class ProvinciaRepository : IRepository<Provincia, int>
    {
        private DBContext context;
        public ProvinciaRepository(DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Provincia> All()
        {
            return this.context.Provincia;
        }

        public bool Delete(int id)
        {
            this.context.Remove(this.context.Provincia.Where(v => v.Id == id).FirstOrDefault());
            return this.context.SaveChanges() > 0;
        }

        public Provincia FindById(int id)
        {
            return this.context.Provincia.Where(v => v.Id == id).FirstOrDefault();
        }

        public bool Save(Provincia item)
        {
            Provincia provincia = this.context.Provincia.Where(v => v.Id == item.Id).FirstOrDefault();
            if(provincia == null)
            {
                this.context.Provincia.Add(item);
            } else
            {
                this.context.Provincia.Update(item);
            }
            return this.context.SaveChanges() > 0;
        }
    }
}
