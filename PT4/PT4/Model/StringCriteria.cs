using System;
using System.Linq.Expressions;

namespace PT4.Model
{
    public class StringCriteria : Criteria<string>
    {
        public StringCriteria(string checkObj) : base(checkObj)
        {
        }

        public override Expression<Predicate<string>> CreateFunctionFromCriteria()
        {
            return (s) => s.Contains(checkObj);
        }
    }
}
