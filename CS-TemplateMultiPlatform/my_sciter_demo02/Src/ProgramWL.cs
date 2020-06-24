#if WINDOWS || GTKMONO
using SciterSharp.Interop;
using System;
using System.Diagnostics;

namespace my_sciter_demo02
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
           // if (IntPtr.Size == 4)
          //  {
         //       Debug.Assert(false, "sciter.dll that comes bundled in my_sciter_demo02 is the x64 version, make sure to change it to the x86 version if building for x86 (Windows only)");
         //   }

#if WINDOWS
            // Sciter needs this for drag'n'drop support; STAThread is required for OleInitialize succeess
            int oleres = PInvokeWindows.OleInitialize(IntPtr.Zero);
            Debug.Assert(oleres == 0);
#endif
#if GTKMONO
			PInvokeGTK.gtk_init(IntPtr.Zero, IntPtr.Zero);
			Mono.Setup();
#endif

            /*
				NOTE:
				In Linux, if you are getting a System.TypeInitializationException below, it is because you don't have 'libsciter-gtk-64.so' in your LD_LIBRARY_PATH.
				Run 'sudo bash install-libsciter.sh' contained in this package to install it in your system.
			*/
            App.Run();
        }
    }
}
#endif