using EventManager.Presneters;
using EventManager.Views;

namespace EventManager
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