namespace PT4.Model
{
    public enum CriteriaCheckType
    {
        EQ,
        NE,
        GOE,
        LOE,
        GT,
        LT
    }

    public static class CriteriaCheckTypeHelper
    {
        public static CriteriaCheckType? FromString(string s)
        {
            switch (s)
            {
                case "=":
                    return CriteriaCheckType.EQ;
                case "!=":
                    return CriteriaCheckType.NE;
                case ">=":
                    return CriteriaCheckType.GOE;
                case "<=":
                    return CriteriaCheckType.LOE;
                case ">":
                    return CriteriaCheckType.GT;
                case "<":
                    return CriteriaCheckType.LT;
                default:
                    return null;
            }
        }
    }
}
