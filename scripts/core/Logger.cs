using Godot;
using System;

namespace Game.Core;

public static class Logger
{
    public static void Log(LogLevel level, params object[] message)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        var callingMethod = new System.Diagnostics.StackTrace().GetFrame(2).GetMethod();
        string logMessage = $"[{timestamp}] [{level}] [{callingMethod.DeclaringType.Name}.{callingMethod.Name}] ";

        var color = "WHITE";
        switch (level)
        {
            case LogLevel.DEBUG:
                color = "CYAN";
                break;
            case LogLevel.WARNING:
                color = "YELLOW";
                break;
            case LogLevel.ERROR:
                color = "RED";
                break;
            default:
                break;
        }

        GD.PrintRich([$"[color={color}]{logMessage}[/color]", ..message]);
    }

    public static void LogDebug(params object[] message)
    {
        Log(LogLevel.DEBUG, message);
    }

    public static void LogInfo(params object[] message)
    {
        Log(LogLevel.INFO, message);
    }

    public static void LogWarning(params object[] message)
    {
        Log(LogLevel.WARNING, message);
    }

    public static void LogError(params object[] message)
    {
        Log(LogLevel.ERROR, message);
    }
}
