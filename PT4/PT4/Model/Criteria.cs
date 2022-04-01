using System;
using System.Linq.Expressions;

namespace PT4.Model
{
    public abstract partial class Criteria<T>
    {
        protected T checkObj;

        public Criteria(T checkObj)
        {
            this.checkObj = checkObj;
        }

        public abstract Expression<Predicate<T>> CreateFunctionFromCriteria();
    }
}
