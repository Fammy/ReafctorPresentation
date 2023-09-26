// Requires C# 6, emhanced in C# 11

namespace RefactorPresentation.B_StringInterpolation;

internal class StringInterpolation
{
    internal void SimplifyStrings()
    {
        const string one = "one";
        const string two = "two";
        const string three = "three";

        var string1 = "1 = " + one + ", 2 = " + two + ", 3 = " + three;
        var string2 = string.Format("1 = {0}, 2 = {1}, 3 = {2}", one, two, three);
    }

    internal void SillyStrings(string message)
    {
        var theOldWay = $"<document>\n<message type=\"display\"{message}</message></document>";

        var theSlightlyBetterWay = $@"<document>
    <message type=""display""{message}</message>
</document>";

        var whoLovesXml = $"""
            <document>
                <message type="display">{message}</message>
            </document>
            """;
    }

    internal ReadOnlySpan<byte> Utf8()
    {
        return "blah"u8;
    }
}
