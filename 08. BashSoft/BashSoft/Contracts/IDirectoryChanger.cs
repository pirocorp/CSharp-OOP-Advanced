namespace BashSoft.Contracts
{
    public interface IDirectoryChanger
    {
        void ChangeCurrentDirectoryAbsolute(string absolutePath);
        void ChangeCurrentDirectoryRelative(string relativePath);
    }
}
