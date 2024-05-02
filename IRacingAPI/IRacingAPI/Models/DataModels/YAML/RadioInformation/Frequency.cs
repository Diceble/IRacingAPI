namespace IRacingAPI.Models.DataModels.YAML.RadioInformation;
public class Frequency
{
    public int FrequencyNum { get; set; }
    public string? FrequencyName { get; set; }
    public int Priority { get; set; }
    public int CarIdx { get; set; }
    public int EntryIdx { get; set; }
    public int ClubID { get; set; }
    public int CanScan { get; set; }
    public int CanSquawk { get; set; }
    public int Muted { get; set; }
    public int IsMutable { get; set; }
    public int IsDeletable { get; set; }
}
