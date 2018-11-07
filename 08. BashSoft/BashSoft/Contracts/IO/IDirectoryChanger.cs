namespace BashSoft.Contracts.IO
{
    public interface IDirectoryChanger
    {
        void ChangeCurrentDirectoryAbsolute(string absolutePath);
        void ChangeCurrentDirectoryRelative(string relativePath);
    }
}
