using IRacingAPI.Models.Enumerations;

namespace IRacingAPI.Models.DataModels.TelemetryData;
public abstract class TelemetryValue
{
    //private readonly bool _exists;
    ///// <summary>
    ///// Whether or not a telemetry value with this name exists on the current car.
    ///// </summary>
    //public bool Exists { get { return _exists; } }

    /// <summary>
    /// The name of this telemetry value parameter.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// The description of this parameter.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// The real world unit for this parameter.
    /// </summary>
    public string? Unit { get; set; }

    /// <summary>
    /// The data-type for this parameter.
    /// </summary>
    public VariableType Type { get; set; }
}

public sealed class TelemetryValue<T> : TelemetryValue
{
    /// <summary>
    /// The value of this parameter.
    /// </summary>
    public T? Value { get; set; }
        
    public override string ToString()
    {
        return string.Format("{0} {1}", this.Value, this.Unit);
    }
}
