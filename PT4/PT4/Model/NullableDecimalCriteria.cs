using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT4.Model
{
    class NullableDecimalCriteria : Criteria<decimal?>
    {
        private CriteriaCheckType CheckType;
        private bool NullAllowed;

        public NullableDecimalCriteria(decimal? checkObj, CriteriaCheckType checkType, bool nullAllowed) : base(checkObj)
        {
            this.CheckType = checkType;
            this.NullAllowed = nullAllowed;
        }

        public override Expression<Predicate<decimal?>> CreateFunctionFromCriteria()
        {
            //(d.HasValue || NullAllowed) returns false iif the nullable doesn't have a value AND null isn't allowed
            //Because AND and OR operations are read left to right
            //If it has a value, d.HasValue is true, and if d.HasValue is false, if null isn't allowed then it stops at the left side
            //and won't evaluate the right side. It IS null-safe.
            

            switch (CheckType)
            {
                case CriteriaCheckType.EQ:
                    return (d) => (d.HasValue || NullAllowed) && (!d.HasValue || d == checkObj);
                case CriteriaCheckType.NE:
                    return (d) => (d.HasValue || NullAllowed) && (!d.HasValue || d != checkObj);
                case CriteriaCheckType.GOE:
                    return (d) => (d.HasValue || NullAllowed) && (!d.HasValue || d >= checkObj);
                case CriteriaCheckType.LOE:
                    return (d) => (d.HasValue || NullAllowed) && (!d.HasValue || d <= checkObj);
                case CriteriaCheckType.GT:
                    return (d) => (d.HasValue || NullAllowed) && (!d.HasValue || d > checkObj);
                case CriteriaCheckType.LT:
                    return (d) => (d.HasValue || NullAllowed) && (!d.HasValue || d < checkObj);
                default:
                    throw new ArgumentException("ERREUR! Il faut un type de vérification!");
            }
        }
    }
}
