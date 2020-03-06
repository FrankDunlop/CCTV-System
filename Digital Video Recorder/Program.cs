using System;
using System.Windows.Forms;
//using DVR.IoC;
using Ninject;
using System.Threading;

namespace DVR
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += ApplicationOnThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

            IKernel kernel = new StandardKernel();

            //CompositionRoot.Wire(new ApplicationModule());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DVRFrm());
            //Application.Run(CompositionRoot.Resolve<DVRFrm>());
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var message = String.Format("Sorry, something went wrong.\r\n" +
                "{0}\r\n" +
                "Please contact support.",
                ((Exception)e.ExceptionObject).Message);

            Console.WriteLine("ERROR {0}: {1}",
                DateTimeOffset.Now, e.ExceptionObject);

            MessageBox.Show(message, "Unexpected Error");

        }

        private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var message = String.Format("Sorry, something went wrong.\r\n" +
              "{0}\r\n" +
              "Please contact support.",
                e.Exception.Message);

            Console.WriteLine("ERROR {0}: {1}",
                DateTimeOffset.Now, e.Exception);

            MessageBox.Show(message, "Unexpected Error");
        }
    }
}
