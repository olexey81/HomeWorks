namespace HW_8_LINQ_3_Menu
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class MenuActionAttribute : Attribute
    {
        public string Title { get; }
        public int Num { get; }

        public MenuActionAttribute(string title, int num)
        {
            Title = title;
            Num = num;
        }

    }

}
