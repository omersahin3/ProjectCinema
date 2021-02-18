using Microsoft.EntityFrameworkCore;
using ProjectCinema.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectCinema.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        Context c = new Context();
        public void TAdd(T p)
        {
            c.Set<T>().Add(p);
            c.SaveChanges();
        }
        public void TRemove(T p)
        {
            c.Set<T>().Remove(p);
            c.SaveChanges();
        }
        public void TUpdate(T p)
        {
            c.Set<T>().Update(p);
            c.SaveChanges();
        }
        public List<T> TList()
        {
            return c.Set<T>().ToList();
        }
        public T GetT(int id)
        {
            return c.Set<T>().Find(id);
        }
        public List<T> TList(string p)
        {
            return c.Set<T>().Include(p).ToList();
        }        
    }
}
