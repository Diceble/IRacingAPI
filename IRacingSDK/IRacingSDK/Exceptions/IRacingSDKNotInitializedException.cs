namespace IRacingSDK.Exceptions;
internal class IRacingSDKNotInitializedException : Exception
{
    public IRacingSDKNotInitializedException() : base("IRacing SDK is not initialized")
    {
    }
}