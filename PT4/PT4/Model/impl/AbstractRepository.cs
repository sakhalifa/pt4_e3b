using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    public abstract class AbstractRepository<T> : IGenericRepository<T>
    {
        protected PT4_PLANNIMAUX_S4p2B_JKVBLBEntities _context;
        private event OnChanged<T> OnChangedHandler;
        private bool disposed = false;

        protected AbstractRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context)
        {
            _context = context;
        }

        public abstract IEnumerable<T> FindAll();

        public abstract IEnumerable<T> FindWhere(Expression<Func<T, bool>> predicate);

        public abstract T FindById(int id);

        public abstract void Insert(T obj);

        public abstract void Delete(int id);

        public abstract void Update(T obj);

        public void Save()
        {
            if (_context.ChangeTracker.HasChanges())
            {
                IEnumerable<DbEntityEntry> entriesChanged = _context.ChangeTracker.Entries();
                List<T> entriesOfTypeChanged = new List<T>();

                foreach (DbEntityEntry entry in entriesChanged)
                {
                    //En gros, vu que c'est des proxies qui héritent des classes entités, j'dois récupérer le type dont l'entité hérite
                    if(entry.Entity.GetType().BaseType == typeof(T))
                    {
                        entriesOfTypeChanged.Add((T)entry.Entity);
                    }
                }

                OnChangedHandler?.Invoke(entriesOfTypeChanged);
                
                
            }
            _context.SaveChanges();

        }

        public void Subscribe(OnChanged<T> onChanged)
        {
            OnChangedHandler += onChanged;
        }

        public void UnSubscribe(OnChanged<T> onChanged)
        {
            OnChangedHandler -= onChanged;
        }
        

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
    }
}
