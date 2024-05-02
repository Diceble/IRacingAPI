namespace IRacingAPI.Models.DataModels.YAML.CarSetupInformation;
public class CarSetup
{
    public int UpdateCount { get; set; }
    public TiresAero? TiresAero { get; set; }
    public Chassis? Chassis { get; set; }
    public InCarDials? InCarDials { get; set; }
}
