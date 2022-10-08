public static class Ports
{
    public static string[] SetLayout(char portChar, params string[] layout)
    {
        int i = 0;
        for (int num = layout.Length; i < num; i++)
        {
            layout[i] = layout[i].Replace('?', portChar);
        }
        return layout;
    }
}
