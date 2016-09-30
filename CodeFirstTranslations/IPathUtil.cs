namespace Creuna.CodeFirstTranslations2
{
    public interface IPathUtil
    {
        string PathSeparator { get; }
        string Combine(string path1, string path2);
    }
}