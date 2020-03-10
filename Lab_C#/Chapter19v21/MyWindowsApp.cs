using System;
using System.Windows.Forms;

namespace MyWindowsApp
{
    // The main windows <MainWindow>.
    public class MainWindow : Form {}
    // The application class.
    // Encapsulates a Windows.Forms application.
    public static class Program
    {
        
        static void Main(string[] args)
        {
            // Starts a Windows.Forms application and 
	    // opens the specified window 
            Application.Run(new MainWindow());
        }
    }
}
