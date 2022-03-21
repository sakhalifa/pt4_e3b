namespace PT4.Model
{
    public enum CriteriaCombinationType
    {
        AND,
        OR
    }

    public static class CriteriaCombinationTypeHelper
    {
        public static CriteriaCombinationType? FromString(string s)
        {
            switch (s)
            {
                case "ET":
                    return CriteriaCombinationType.AND;
                case "OU":
                    return CriteriaCombinationType.OR;
                default:
                    return null;
            }
        }
    }
}
