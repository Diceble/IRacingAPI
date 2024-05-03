using IRacingAPI.Models.Enumerations;
using System.Reflection.PortableExecutable;

namespace IRacingAPI.Models.DataModels.TelemetryData;
public abstract class TelemetryValue
{
    private readonly bool _exists;
    /// <summary>
    /// Whether or not a telemetry value with this name exists on the current car.
    /// </summary>
    public bool Exists { get { return _exists; } }

    private readonly string _name;
    /// <summary>
    /// The name of this telemetry value parameter.
    /// </summary>
    public string Name { get { return _name; } }

    private readonly string _description;
    /// <summary>
    /// The description of this parameter.
    /// </summary>
    public string Description { get { return _description; } }

    private readonly string _unit;
    /// <summary>
    /// The real world unit for this parameter.
    /// </summary>
    public string Unit { get { return _unit; } }

    private readonly VariableType _type;
    /// <summary>
    /// The data-type for this parameter.
    /// </summary>
    public VariableType Type { get { return _type; } }

}
