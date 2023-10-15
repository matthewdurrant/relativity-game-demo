namespace RelativityDemo
{
    /// <summary>
    /// An interface to output text to the user.
    /// To begin with, this will literally just be the Windows console, but in future this could plug into something a bit cooler.
    /// </summary>
    public interface IShipTerminal
    {
        void WriteLine(string text);
        void WriteLine();
        float GetFloat();
        int GetInt();
        void WriteBlue(string text);
        void WriteError(string text);
        void WriteSuccess(string text);
        void Spinner(int time);
        void Exit();
        void Clear();
    }
}
