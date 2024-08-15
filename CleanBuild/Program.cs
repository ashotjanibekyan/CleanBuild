using CleanBuild;

var arguments = Environment.GetCommandLineArgs();

string root;
string[] folders = ["bin", "obj"];
if (arguments.IndexOf("--f", out var index))
{
    root = index > 1 ? Path.GetFullPath(arguments.NthOrDefault(1) ?? ".") : Path.GetFullPath(".");
    folders = arguments[(index + 1)..];
}
else
{
    root = Path.GetFullPath(arguments.NthOrDefault(1) ?? ".");
}

DeleteBinsAndObjs(root, folders);

Console.WriteLine("Done");
return;

static void DeleteBinsAndObjs(string path, string[] folders)
{
    if (!Directory.Exists(path))
    {
        return;
    }

    foreach (var folder in folders)
    {
        var folderPath = Path.Combine(path, folder);
        if (!Directory.Exists(folderPath))
        {
            continue;
        }

        Directory.Delete(folderPath, true);
        Console.WriteLine($">> {folderPath} deleted");
    }

    foreach (var subDir in Directory.GetDirectories(path))
    {
        DeleteBinsAndObjs(subDir, folders);
    }
}
