using static System.Net.Mime.MediaTypeNames;

namespace IRacingAPI.Models.DataModels.YAML.CarSetupInformation;
public class Chassis
{
    public Front? Front { get; set; }
    public LeftFront? LeftFront { get; set; }
    public LeftRear? LeftRear { get; set; }
    public RightFront? RightFront { get; set; }
    public RightRear? RightRear { get; set; }
    public Rear? Rear { get; set; }
}
