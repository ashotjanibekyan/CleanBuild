using CleanBuild;

string? root = Environment.GetCommandLineArgs().NthOrDefault(1);

DeleteBinsAndObjs(root);

static void DeleteBinsAndObjs(string? path)
{
    path = Path.GetFullPath(path ?? ".");
    if (!Directory.Exists(path))
    {
        return;
    }

    string binPath = Path.Combine(path, "bin");
    if (Directory.Exists(binPath))
    {
        Directory.Delete(binPath, true);
        Console.WriteLine($">> {binPath} deleted");
    }
    string objPath = Path.Combine(path, "obj");
    if (Directory.Exists(objPath))
    {
        Directory.Delete(objPath, true);
        Console.WriteLine($">> {objPath} deleted");
    }

    foreach (string subDir in Directory.GetDirectories(path))
    {
        DeleteBinsAndObjs(subDir);
    }
}
Console.WriteLine("Done");
