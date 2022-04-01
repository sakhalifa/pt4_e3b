using System;
using System.Linq.Expressions;

namespace PT4.Model
{
    public class BoolCriteria : Criteria<bool>
    {
        public BoolCriteria(bool checkObj) : base(checkObj)
        {
        }

        public override Expression<Predicate<bool>> CreateFunctionFromCriteria()
        {
            return (b) => b == checkObj;
        }
    }
}
