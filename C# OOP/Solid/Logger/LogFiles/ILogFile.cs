namespace Solid.LogFiles
{
   
    public interface ILogFile
    {
        int Size { get; }
        void Write(string message);
    }
}
