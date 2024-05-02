namespace IRacingAPI.Models.DataModels.YAML.SessionInformation;
public class Session
{
    public int SessionNum { get; set; }
    public string? SessionLaps { get; set; }
    public string? SessionTime { get; set; }
    public int SessionNumLapsToAvg { get; set; }
    public string? SessionType { get; set; }
    public string? SessionTrackRubberState { get; set; }
    public string? SessionName { get; set; }
    public string? SessionSubType { get; set; }
    public int SessionSkipped { get; set; }
    public int SessionRunGroupsUsed { get; set; }
    public int SessionEnforceTireCompoundChange { get; set; }
    public Results? Results { get; set; }
}
