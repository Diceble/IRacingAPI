namespace IRacingAPI.Models.DataModels.YAML.SessionInformation;
public class Results
{
    public List<ResultsPosition>? ResultsPositions { get; set; }
    public List<ResultsFastestLap>? ResultsFastestLap { get; set; }
    public float ResultsAverageLapTime { get; set; }
    public int ResultsNumCautionFlags { get; set; }
    public int ResultsNumCautionLaps { get; set; }
    public int ResultsNumLeadChanges { get; set; }
    public int ResultsLapsComplete { get; set; }
    public int ResultsOfficial { get; set; }
}
