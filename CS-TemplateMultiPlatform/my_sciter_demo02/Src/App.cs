using my_sciter_demo02.Src;
using SciterSharp;
using SciterSharp.Interop;
using System;

namespace my_sciter_demo02
{
    class SciterMessages : SciterDebugOutputHandler
    {
        protected override void OnOutput(SciterSharp.Interop.SciterXDef.OUTPUT_SUBSYTEM subsystem, SciterSharp.Interop.SciterXDef.OUTPUT_SEVERITY severity, string text)
        {
            Console.WriteLine(text);// prints to console Sciter's debug output (works even if 'native debugging' is off)
        }
    }

    static class App
    {
        private static SciterMessages sm = new SciterMessages();

        public static WndMain mainWnd { get; private set; }

        public static Host AppHost { get; private set; }

        public static void Run()
        {
            // Create the window
            mainWnd = new WndMain();

            // Prepares SciterHost and then load the page
            AppHost = new Host(mainWnd);
            
            mainWnd.getMsg();
#if !OSX
            PInvokeUtils.RunMsgLoop();
            FinalizeApp();
#endif
        }

        public static void FinalizeApp()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}