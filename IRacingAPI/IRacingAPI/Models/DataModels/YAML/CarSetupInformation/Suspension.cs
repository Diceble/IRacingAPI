namespace IRacingAPI.Models.DataModels.YAML.CarSetupInformation;
public abstract class Suspension
{
    public string? CornerWeight { get; set; }
    public string? RideHeight { get; set; }
    public string? SpringPerchOffset { get; set; }
    public string? SpringRate { get; set; }
    public string? LsCompDamping { get; set; }
    public string? HsCompDamping { get; set; }
    public string? LsRbdDamping { get; set; }
    public string? HsRbdDamping { get; set; }
    public string? Camber { get; set; }
}
