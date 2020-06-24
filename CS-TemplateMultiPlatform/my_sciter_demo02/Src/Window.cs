using SciterSharp;

namespace my_sciter_demo02
{
    public class Window : SciterWindow
    {
        public Window()
        {
            var wnd = this;
            wnd.CreateMainWindow(900, 800);
            wnd.CenterTopLevelWindow();
            wnd.Title = "my_sciter_demo02";
#if WINDOWS
            wnd.Icon = Properties.Resources.IconMain;
#endif
        }
    }
}