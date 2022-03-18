using Moq;
using PT4.Model.dal;
using PT4.Model.impl;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace TestProjetVeto
{
    public class Utils
    {
        public static DbSet<T> CreateDbSet<T>(List<T> collection) where T : class
        {
            var queryable = collection.AsQueryable();

            var stubDbSet = new Mock<DbSet<T>>();
            stubDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            stubDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            stubDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            stubDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            stubDbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => collection.Add(s));
            stubDbSet.Setup(d => d.Remove(It.IsAny<T>())).Callback<T>((s) => collection.Remove(s));
            stubDbSet.Object.AsNoTracking();
            return stubDbSet.Object;
        }

        public static Mock<T> CreateMockRepo<T, V>(DbContext ctx) where T : AbstractRepository<V>
        {
            var mockRepo = new Mock<T>(ctx);
            mockRepo.Setup(c => c.Save()).Callback(() => { return; });
            mockRepo.CallBase = true;

            return mockRepo;
        }
    }
}
