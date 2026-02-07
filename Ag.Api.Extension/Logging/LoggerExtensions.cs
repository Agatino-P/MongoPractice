namespace Ag.Api.Extension.Logging;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

public static partial class LoggerExtensions
{
    extension(ILogger logger)
    {
        public void LogMemberCalled(
            [CallerMemberName] string methodName = "",
            [CallerFilePath] string filePath = "")
        {
            executeLogMember(logger,filePath, methodName, "No payload");
        }

        public void LogMemberCalled(object payload,
            [CallerMemberName] string methodName = "",
            [CallerFilePath] string filePath = "")
        {
            executeLogMember(logger,filePath, methodName, CustomJson.Serialize(payload));
        }
    }

    [LoggerMessage(
        EventId = -1,
        Level = LogLevel.Information,
        Message = "{className}.{methodName} was called with payload: {jsonPayload}")]
    private static partial void executeLogMember(
        ILogger logger, 
        string className, 
        string methodName, 
        string? jsonPayload);
}