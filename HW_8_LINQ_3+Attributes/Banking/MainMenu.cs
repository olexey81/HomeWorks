using HW_8_LINQ_3_Menu;

namespace HW_4_Bank
{
    public class MainMenu
    {
        [SubMenu("Login as manager", 1)]                               // елементи головного менб - підменю
        public ManagerMainMenu SubMenuManager { get; set; }


        [SubMenu("Login as client", 2)]                               // елементи головного менб - підменю
        public ClientMainMenu SubMenuClient { get; set; }


        [MenuAction("Exit", 0)]                             // елементи головного меню - вихід з програми
        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
