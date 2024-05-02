namespace IRacingAPI.Models.DataModels.YAML.CameraInformation;
public class Group
{
    public int GroupNum { get; set; }
    public string? GroupName { get; set; }
    public bool IsScenic { get; set; }
    public List<Camera>? Cameras { get; set; }
}
