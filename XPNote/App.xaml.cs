using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XPNote.Views;
using System.Windows;
using XPNote.ViewModels;
using System.IO;
using Microsoft.Extensions.Logging;

using Serilog;
using CommunityToolkit.Mvvm.Messaging;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.Win32;

namespace XPNote
{

    public partial class App : Application
    {

        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                using var host = CreateHostBuilder(args).Build();
                host.Start();
                var logger = host.Services.GetRequiredService<ILogger<App>>();
                App app = new App();
                app.InitializeComponent();
                var login = host.Services.GetRequiredService<LoginView>();
                
                app.MainWindow = host.Services.GetRequiredService<LoginView>();
                app.MainWindow.Visibility = Visibility.Visible;
                app.Run();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("找不到配置文件appsettings.json");
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config =>
                {

                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    config.AddCommandLine(args);
                    config.AddEnvironmentVariables();
                })
                .ConfigureServices(container =>
                {
                    container.AddSingleton<MainWindowViewModel>()
                             .AddSingleton(sp => new MainWindow() { DataContext = sp.GetService<MainWindowViewModel>() })
                             .AddSingleton<LoginViewModel>()
                             .AddSingleton(sp => new LoginView() { DataContext = sp.GetService<LoginViewModel>() })
                             .AddSingleton<WeakReferenceMessenger>()
                             .AddSingleton<IMessenger, WeakReferenceMessenger>(provider => 
                             provider.GetRequiredService<WeakReferenceMessenger>());
                             
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    Log.Logger = new LoggerConfiguration()
                                   .WriteTo.File("Log/log.txt", rollingInterval:RollingInterval.Day, retainedFileCountLimit:10)
                                   .WriteTo.Console()
                                   .CreateLogger();
                    logging.AddSerilog(Log.Logger);
                });
        }
    }
}
