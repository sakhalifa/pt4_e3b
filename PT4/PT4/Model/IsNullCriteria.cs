using System;
using System.Linq.Expressions;

namespace PT4.Model
{
    class IsNullCriteria : Criteria<object>
    {
        private CriteriaCheckType CheckType;

        public IsNullCriteria(CriteriaCheckType checkType) : base(null)
        {
            this.CheckType = checkType;
        }

        public override Expression<Predicate<object>> CreateFunctionFromCriteria()
        {
            switch (CheckType)
            {
                case CriteriaCheckType.EQ:
                    return (o) => o == null;
                case CriteriaCheckType.NE:
                    return (o) => o != null;
                default:
                    throw new ArgumentException("ERREUR! Ce générateur de fonction de critères n'accepte que != et == !!");
            }
        }

    }
}
