using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows;

namespace AdministratorApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            CultureInfo frenchCanadianCulture = new CultureInfo("fr-CA");
            Thread.CurrentThread.CurrentCulture = frenchCanadianCulture;
            Thread.CurrentThread.CurrentUICulture = frenchCanadianCulture;

            // Other startup code
        }
    }

}
