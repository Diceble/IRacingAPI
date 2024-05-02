using IRacingAPI.Models;

namespace IRacingAPI.Abstractions;

public interface IIRacingDataApi
{
    object GetData(string name);
    string GetSessionData();
    bool IsConnected();
    void ShutDown();
    bool StartUp();
    IRSDKHeader GetIRSDKHeader();
}