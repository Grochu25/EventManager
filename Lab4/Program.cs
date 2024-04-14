using Lab4.Presneters;
using Lab4.Views;

namespace Lab4
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            IEventView eventView = new EventView();
            new EventPresenter(eventView);
            Application.Run((EventView) eventView);
        }
    }
}