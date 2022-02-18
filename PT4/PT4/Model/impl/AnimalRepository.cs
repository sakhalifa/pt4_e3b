﻿using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class AnimalRepository : IAnimalRepository, IDisposable
    {
        private PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context;

        public AnimalRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context)
        {
            this.context = context;
        }

        public IEnumerable<ANIMAL> FindAll()
        {
            return context.ANIMAL.ToList();
        }

        public ANIMAL FindById(int animalId)
        {
            return context.ANIMAL.Find(animalId);
        }

        public void Insert(ANIMAL animal)
        {
            context.ANIMAL.Add(animal);
        }

        public void Delete(int animalId)
        {
            context.ANIMAL.Remove(context.ANIMAL.Find(animalId));
        }

        public void Update(ANIMAL animal)
        {
            context.Entry(animal).State = System.Data.Entity.EntityState.Modified;
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

        public IEnumerable<CONGÉ> FindWhere(Expression<Func<ANIMAL, bool>> predicate)
        {
            return context.ANIMAL.Where(predicate);
        }
    }
}
