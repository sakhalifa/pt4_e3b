﻿using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model.impl
{
    public class AnimalRepository : AbstractRepository<ANIMAL>
    {
        public AnimalRepository(DbContext context) : base(context)
        {
        }

        public override IQueryable<ANIMAL> FindAll()
        {
            return _context.Set<ANIMAL>().AsQueryable();
        }

        public override ANIMAL FindById(int animalId)
        {
            return _context.Set<ANIMAL>().Find(animalId);
        }

        public override void Insert(ANIMAL animal)
        {
            _context.Set<ANIMAL>().Add(animal);
        }

        public override void Delete(ANIMAL obj)
        {
            _context.Set<ANIMAL>().Remove(obj);
        }

        public override void Update(ANIMAL animal)
        {
            _context.Entry(animal).State = EntityState.Modified;
        }

        public override IQueryable<ANIMAL> FindWhere(Expression<Func<ANIMAL, bool>> predicate)
        {
            return _context.Set<ANIMAL>().Where(predicate);
        }
    }
}
