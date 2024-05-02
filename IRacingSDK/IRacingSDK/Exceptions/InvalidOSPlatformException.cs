namespace IRacingSDK.Exceptions;
internal class InvalidOSPlatformException : Exception
{
    public InvalidOSPlatformException() : base("Invalid OS Platform")
    {
    }

    public InvalidOSPlatformException(string operatingSystem) : base($"{operatingSystem} is not supported by the IRacing SDK")
    {
    }
}
