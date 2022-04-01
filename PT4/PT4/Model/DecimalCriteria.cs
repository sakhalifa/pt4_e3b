using System;
using System.Linq.Expressions;

namespace PT4.Model
{
    public class DecimalCriteria : Criteria<decimal>
    {
        private CriteriaCheckType checkType;

        public DecimalCriteria(decimal checkObj, CriteriaCheckType checkType) : base(checkObj)
        {
            this.checkType = checkType;
        }

        public override Expression<Predicate<decimal>> CreateFunctionFromCriteria()
        {
            switch (checkType)
            {
                case CriteriaCheckType.EQ:
                    return (d) => d == checkObj;
                case CriteriaCheckType.NE:
                    return (d) => d != checkObj;
                case CriteriaCheckType.GOE:
                    return (d) => d >= checkObj;
                case CriteriaCheckType.LOE:
                    return (d) => d <= checkObj;
                case CriteriaCheckType.GT:
                    return (d) => d > checkObj;
                case CriteriaCheckType.LT:
                    return (d) => d < checkObj;
                default:
                    throw new ArgumentException("ERREUR! Il faut un type de vérification!");
            }
        }
    }
}
