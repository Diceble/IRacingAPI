namespace IRacingAPI.Models.DataModels.YAML.DriverInformation;
public class DriverInfo
{
    public int DriverCarIdx { get; set; }
    public int DriverUserID { get; set; }
    public int PaceCarIdx { get; set; }
    public float DriverHeadPosX { get; set; }
    public float DriverHeadPosY { get; set; }
    public float DriverHeadPosZ { get; set; }
    public int DriverCarIsElectric { get; set; }
    public float DriverCarIdleRPM { get; set; }
    public float DriverCarRedLine { get; set; }
    public int DriverCarEngCylinderCount { get; set; }
    public float DriverCarFuelKgPerLtr { get; set; }
    public float DriverCarFuelMaxLtr { get; set; }
    public float DriverCarMaxFuelPct { get; set; }
    public int DriverCarGearNumForward { get; set; }
    public int DriverCarGearNeutral { get; set; }
    public int DriverCarGearReverse { get; set; }
    public float DriverCarSLFirstRPM { get; set; }
    public float DriverCarSLShiftRPM { get; set; }
    public float DriverCarSLLastRPM { get; set; }
    public float DriverCarSLBlinkRPM { get; set; }
    public string? DriverCarVersion { get; set; }
    public float DriverPitTrkPct { get; set; }
    public float DriverCarEstLapTime { get; set; }
    public string? DriverSetupName { get; set; }
    public int DriverSetupIsModified { get; set; }
    public string? DriverSetupLoadTypeName { get; set; }
    public int DriverSetupPassedTech { get; set; }
    public int DriverIncidentCount { get; set; }
    public List<Driver>? Drivers { get; set; }
}
