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
    public class UsoRepository : IRepository<Uso, int>
    {
        private DBContext context;
        public UsoRepository(DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Uso> All()
        {
            return this.context.Uso;
        }

        public bool Delete(int id)
        {
            this.context.Remove(this.context.Uso.Where(v => v.Id == id).FirstOrDefault());
            return this.context.SaveChanges() > 0;
        }

        public Uso FindById(int id)
        {
            return this.context.Uso.Where(v => v.Id == id).FirstOrDefault();
        }

        public bool Save(Uso item)
        {
            Uso uso = this.context.Uso.Where(v => v.Id == item.Id).FirstOrDefault();
            if(uso == null)
            {
                this.context.Uso.Add(item);
            } else
            {
                this.context.Uso.Update(item);
            }
            return this.context.SaveChanges() > 0;
        }
    }
}
