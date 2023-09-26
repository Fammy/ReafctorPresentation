// Requires C# 8
namespace RefactorPresentation.G_StaticLocalFunctions;

internal class StaticLocalFunctions
{
    public bool IsRecent(DateTime eventTime)
    {
        return WithinLastSeconds(eventTime, 5);

        static bool WithinLastSeconds(DateTime time, int seconds)
        {
            return time.AddSeconds(-seconds) > DateTime.UtcNow;
        }
    }
}
