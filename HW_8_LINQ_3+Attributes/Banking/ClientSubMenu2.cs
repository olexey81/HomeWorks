using HW_8_LINQ_3_Menu;

namespace HW_4_Bank
{
    public class ClientSubMenu2
    {
        [MenuAction("Some option", 1)]
        public void DoSomething()
        {

        }

        [MenuAction("Back", 0)]
        public void Back()
        {
            Menu.DetectMenu<ClientSubMenu>().Process();
            ExitMenuItem();
        }

    }
}