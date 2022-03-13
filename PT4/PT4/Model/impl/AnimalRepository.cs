using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    class AnimalRepository : IGenericRepository<ANIMAL>, IDisposable
    {
        private PT4_PLANNIMAUX_S4p2B_JKVBLBEntities _context;

        public AnimalRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context)
        {
            this._context = context;
        }


        public IEnumerable<ANIMAL> FindAll()
        {
            return _context.ANIMAL.ToList();
        }

        public ANIMAL FindById(int animalId)
        {
            return _context.ANIMAL.Find(animalId);
        }

        public void Insert(ANIMAL animal)
        {
            _context.ANIMAL.Add(animal);
        }

        public void Delete(int animalId)
        {
            _context.ANIMAL.Remove(_context.ANIMAL.Find(animalId));
        }

        public void Update(ANIMAL animal)
        {
            _context.Entry(animal).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ANIMAL> FindWhere(Expression<Func<ANIMAL, bool>> predicate)
        {
            return _context.ANIMAL.Where(predicate);
        }
    }
}
