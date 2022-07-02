namespace Paas.Pioneer.Domain.Shared.BaseEnum
{
    public enum DynamicQueryOperator
    {
        Equal,            // 0
        NotEqual,
        Greater,
        GreaterOrEqual,
        Less,
        LessOrEqual,        // 5
        StartWith,
        NotStartWith,
        EndWith,
        NotEndWith,
        Contain,
        NotContain        // 11
    }
}