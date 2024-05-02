using IRacingAPI.Models.DataModels.YAML.CameraInformation;
using IRacingAPI.Models.DataModels.YAML.CarSetupInformation;
using IRacingAPI.Models.DataModels.YAML.DriverInformation;
using IRacingAPI.Models.DataModels.YAML.RadioInformation;
using IRacingAPI.Models.DataModels.YAML.SectorInformation;
using IRacingAPI.Models.DataModels.YAML.SessionInformation;
using IRacingAPI.Models.DataModels.YAML.WeekendInformation;

namespace IRacingAPI.Models.DataModels.YAML;
public class SessionData
{
    public WeekendInfo? WeekendInfo { get; set; }
    public SessionInfo? SessionInfo { get; set; }
    public CameraInfo? CameraInfo { get; set; }
    public RadioInfo? RadioInfo { get; set; }
    public DriverInfo? DriverInfo { get; set; }
    public SplitTimeInfo? SplitTimeInfo { get; set; }
    public CarSetup? CarSetup { get; set; }
}
