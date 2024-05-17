using IRacingAPI.Models;
using IRacingAPI.Models.DataModels.TelemetryData;

namespace IRacingAPI.Abstractions;

public interface IIRacingApi
{
    T[] ReadValueByVariableHeaderName<T>(string name) where T : struct;
    string GetSessionData();
    bool IsConnected();
    void ShutDown();
    bool StartUp();
    IRSDKHeader? GetIRSDKHeader();
    TelemetryInfo GetTelemetryInfo();
}