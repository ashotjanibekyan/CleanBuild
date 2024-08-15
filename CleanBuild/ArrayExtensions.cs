namespace CleanBuild;

public static class ArrayExtensions
{
    public static T? NthOrDefault<T>(this T[] array, int i)
    {
        return array.Length > i ? array[i] : default;
    }

    public static bool IndexOf<T>(this T[] array, T item, out int index)
    {
        index = Array.IndexOf(array, item);
        return index != -1;
    }
}
