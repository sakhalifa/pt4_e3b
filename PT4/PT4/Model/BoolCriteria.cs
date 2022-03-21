using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
