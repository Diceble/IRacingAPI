namespace IRacingAPI.Models.DataModels.YAML.RadioInformation;
public class Radio
{
    public int RadioNum { get; set; }
    public int HopCount { get; set; }
    public int NumFrequencies { get; set; }
    public int TunedToFrequencyNum { get; set; }
    public int ScanningIsOn { get; set; }
    public List<Frequency>? Frequencies { get; set; }
}
