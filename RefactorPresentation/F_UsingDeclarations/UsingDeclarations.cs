// Requires C# 8

namespace RefactorPresentation.F_UsingDeclarations;

internal class UsingDeclarations
{
    public void ReadAllData(string filename)
    {
        using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
        {
            using (var ms = new MemoryStream())
            {
                var bytes = new byte[fs.Length];
                fs.Read(bytes, 0, (int)fs.Length);
                ms.Write(bytes, 0, (int)fs.Length);
            }
        }
    }
}
