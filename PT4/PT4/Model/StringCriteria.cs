using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
