using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SciterSharp;

namespace my_sciter_demo02.Src
{
    class WndMain : SciterWindow
    {
        private WndMain winMain = null;

        // 构造函数，创建窗口
        public WndMain()
        {
            winMain = this;
            winMain.CreateMainWindow(860, 640);
            winMain.CenterTopLevelWindow();
            winMain.Title = "my_sciter_demo02";
            winMain.Icon = Properties.Resources.IconMain;
        }

        public void getMsg()
        {
            var sv = SciterValue.FromObject(new
			{
				data = "发给ui",
				code = 1
			});
            SciterValue[] param = new SciterValue[1];
            param[0] = sv;
            winMain.CallFunction("HostCallable.getMsgTest", param);
        }
    }
}
