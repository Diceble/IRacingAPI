using IRacingAPI.Models;
using IRacingAPI.Models.DataModels.TelemetryData;

namespace IRacingAPI.Abstractions;

public interface IIRacingApi
{
    object GetDataByVariableHeaderName(string name);
    string GetSessionData();
    bool IsConnected();
    void ShutDown();
    bool StartUp();
    IRSDKHeader? GetIRSDKHeader();
    TelemetryInfo GetTelemetryInfo();
}