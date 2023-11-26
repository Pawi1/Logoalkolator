using System;
using Gtk;
using System.Globalization;

namespace GtkApplication2
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            Application.Init();
            var app = new Application("org.GtkApplication2.GtkApplication2", GLib.ApplicationFlags.None);
            var win = new MainWindow();
            app.Register(GLib.Cancellable.Current);
            app.AddWindow(win);
            win.Show();
            Application.Run();
        }
    }
}