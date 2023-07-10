using HW_8_LINQ_3_Menu;

namespace HW_4_Bank
{
    public class ManagerMainMenu
    {
        [SubMenu("Login", 1)]                               // елементи головного менб - підменю
        public ManagerSubMenu SubMenu { get; set; }


        [MenuAction("Back", 0)]                             // елементи головного меню - вихід з програми
        public void Back()
        {
            Menu.DetectMenu<MainMenu>().Process();
        }
    }
}
