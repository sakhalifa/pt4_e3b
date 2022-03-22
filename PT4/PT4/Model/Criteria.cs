using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
