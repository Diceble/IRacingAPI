using IRacingSDK.Models;

namespace IRacingSDK.Abstractions;

public interface IIRacingSDK
{
    object GetData(string name);
    string GetSessionData();
    bool IsConnected();
    void ShutDown();
    bool StartUp();
    IRSDKHeader GetIRSDKHeader();
}