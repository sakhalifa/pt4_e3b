using System;
using System.Linq.Expressions;

namespace PT4.Model
{
    class ShortCriteria : Criteria<short>
    {
        private CriteriaCheckType checkType;

        public ShortCriteria(short checkObj, CriteriaCheckType checkType) : base(checkObj)
        {
            this.checkType = checkType;
        }

        public override Expression<Predicate<short>> CreateFunctionFromCriteria()
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
