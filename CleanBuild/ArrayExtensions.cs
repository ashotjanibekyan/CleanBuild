namespace CleanBuild;

public static class ArrayExtensions
{
    public static T? NthOrDefault<T>(this T[] array, int i)
    {
        if (array.Length > i)
        {
            return array[i];
        }
        return default;
    }
}
