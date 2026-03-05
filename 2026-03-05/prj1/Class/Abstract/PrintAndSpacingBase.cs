public abstract class PrintAndSpacingBase
{
    protected static string TxtSpacing()
    {
        byte leftPad = 5;
        byte rightPad = 5;
        char separator = '|';
        return $"{new string(' ', leftPad)}{separator}{new string(' ', rightPad)}";
    }
}