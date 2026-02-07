namespace Ag.Api.Extension.Logging;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

public static partial class LoggerExtensions
{
    public static void LogMemberCalled(
        this ILogger logger,
        string? jsonPayload=null,
        [CallerMemberName] string methodName = "",
        [CallerFilePath] string filePath = "")
    {
        executeLogMember(logger, filePath, methodName, jsonPayload??"No Payload");
    }
    
    [LoggerMessage(
        EventId = -1,
        Level = LogLevel.Information,
        Message = "{className}.{methodName} was called with payload {jsonPayload}")]
    private static partial void executeLogMember(
        ILogger logger, 
        string className, 
        string methodName, 
        string? jsonPayload);
}