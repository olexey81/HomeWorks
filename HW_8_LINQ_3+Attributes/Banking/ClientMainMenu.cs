using HW_8_LINQ_3_Menu;

namespace HW_4_Bank
{
    public class ClientMainMenu
    {
        [SubMenu("Login", 1)]                               // елементи головного менб - підменю
        public ClientSubMenu SubMenu { get; set; }


        [MenuAction("Exit", 0)]                             // елементи головного меню - вихід з програми
        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
