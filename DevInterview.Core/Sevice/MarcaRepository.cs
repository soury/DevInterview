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
    public class MarcaRepository : IRepository<Marca, int>
    {
        private DBContext context;
        public MarcaRepository(DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Marca> All()
        {
            return this.context.Marca;
        }

        public bool Delete(int id)
        {
            this.context.Remove(this.context.Marca.Where(v => v.Id == id).FirstOrDefault());
            return this.context.SaveChanges() > 0;
        }

        public Marca FindById(int id)
        {
            return this.context.Marca.Where(v => v.Id == id).FirstOrDefault();
        }

        public bool Save(Marca item)
        {
            Marca marca = this.context.Marca.Where(v => v.Id == item.Id).FirstOrDefault();
            if(marca == null)
            {
                this.context.Marca.Add(item);
            } else
            {
                this.context.Marca.Update(item);
            }
            return this.context.SaveChanges() > 0;
        }
    }
}
