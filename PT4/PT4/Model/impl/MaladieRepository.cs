﻿using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class MaladieRepository : IMaladieRepository, IDisposable
    {
        private PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context;

        public MaladieRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context)
        {
            this.context = context;
        }

        public IEnumerable<MALADIE> FindAll()
        {
            return context.MALADIE.ToList();
        }

        public MALADIE FindById(int id)
        {
            return context.MALADIE.Find(id);
        }

        public void Insert(MALADIE obj)
        {
            context.MALADIE.Add(obj);
        }

        public void Delete(int id)
        {
            context.MALADIE.Remove(context.MALADIE.Find(id));
        }

        public void Update(MALADIE obj)
        {
            context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
