using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    public class AnimalRepository : AbstractRepository<ANIMAL>
    {
        public AnimalRepository(PT4_PLANNIMAUX_S4p2B_JKVBLBEntities context) : base(context)
        {
        }

        public override IEnumerable<ANIMAL> FindAll()
        {
            return _context.ANIMAL.ToList();
        }

        public override ANIMAL FindById(int animalId)
        {
            return _context.ANIMAL.Find(animalId);
        }

        public override void Insert(ANIMAL animal)
        {
            _context.ANIMAL.Add(animal);
        }

        public override void Delete(int animalId)
        {
            _context.ANIMAL.Remove(_context.ANIMAL.Find(animalId));
        }

        public override void Update(ANIMAL animal)
        {
            _context.Entry(animal).State = System.Data.Entity.EntityState.Modified;
        }

        public override IEnumerable<ANIMAL> FindWhere(Expression<Func<ANIMAL, bool>> predicate)
        {
            return _context.ANIMAL.Where(predicate);
        }
    }
}
