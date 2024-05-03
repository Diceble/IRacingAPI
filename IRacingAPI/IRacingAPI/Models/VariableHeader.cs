using IRacingAPI.Models.Enumerations;

namespace IRacingAPI.Models;

/// <summary>
/// Class that contains the information of the variable header
/// </summary>
/// <param name="TypeOfVariable">Indicates what type the variable is</param>
/// <param name="Offset">Indicates how many bytes from the start of the telemetry buffer exists</param>
/// <param name="Count">Indicates how many values it contains</param>
/// <param name="Name">Name of the variable</param>
/// <param name="Desc">Description of the variable</param>
/// <param name="Unit">Unit used of the variable</param>
public record VariableHeader(VariableType TypeOfVariable, int Offset, int Count, string Name, string Desc, string Unit)
{
    /// <summary>
    /// Gets the number of bytes the variable uses
    /// </summary>
    public int Bytes
    {
        get
        {
            if (TypeOfVariable is VariableType.irChar or VariableType.irBool)
            {
                return 1;
            }
            else if (TypeOfVariable is VariableType.irInt or VariableType.irBitField or VariableType.irFloat)
            {
                return 4;
            }
            else if (TypeOfVariable == VariableType.irDouble)
            {
                return 8;
            }

            return 0;
        }
    }

    /// <summary>
    /// Gets the length of the variable in bytes
    /// </summary>
    public int Length => Bytes * Count;
}