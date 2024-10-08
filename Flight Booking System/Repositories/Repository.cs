﻿using Flight_Booking_System.Context;
using Microsoft.EntityFrameworkCore;

namespace Flight_Booking_System.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly BookingContext Context;

        public Repository(BookingContext _context)
        {
            Context = _context;
        }

        public void Delete(T item)
        {
            Context.Remove(item);
        }

        public List<T> GetAll(string include = null)
        {
            if (include == null)  
            {
                return Context.Set<T>().ToList();
            }
            return Context.Set<T>().Include(include).ToList();
        }

        public T GetById(int? Id)
        {
            return Context.Set<T>().Find(Id);
        }

        public List<T> Get(Func<T, bool> where)
        {
            return Context.Set<T>().Where(where).ToList();
        }

        public void Insert(T item)
        {
            Context.Add(item);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(T item)
        {
            Context.Update(item);
        }

    }
}
