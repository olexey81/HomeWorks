namespace HW_8_LINQ_3_Menu
{
    public interface IMenu : IMenuItem
    {
        IEnumerable<IMenuItem> Items { get; }
    }
}
