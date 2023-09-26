// Requires C# 8

namespace RefactorPresentation.D_SwitchExpressions;

internal class SwitchExpressions
{
    public string IntToEnglish(int i)
    {
        string result;

        switch (i)
        {
            case 0:
                result = "zero";
                break;

            case 1:
                result = "one";
                break;

            case 2:
                result = "two";
                break;

            case 3:
                result = "three";
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(i), "I am lazy");
        }
        
        return result;
    }
}
