namespace HW_8_LINQ_3_Menu
{
    public interface IMenuItem
    {
        string Title { get; }
        int Num { get; }
        bool Process();
    }
}
