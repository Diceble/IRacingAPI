namespace IRacingSDK.Exceptions;
internal class VariableHeaderNotFoundException : Exception
{
    public VariableHeaderNotFoundException() : base("Variable header does not exist")
    {
    }

    public VariableHeaderNotFoundException(string variableName) : base($"Variable header for {variableName} does not exist")
    {
    }
}
