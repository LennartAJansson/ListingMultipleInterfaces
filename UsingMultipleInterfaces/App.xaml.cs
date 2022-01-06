namespace UsingMultipleInterfaces
{
    using System.Windows;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using UsingMultipleInterfaces.Services;
    using UsingMultipleInterfaces.ViewModels;
    using UsingMultipleInterfaces.Views;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost? host;
        protected override void OnStartup(StartupEventArgs e)
        {
            host = Host.CreateDefaultBuilder(e.Args)
                .ConfigureServices((hostBuilderContext, services) =>
                {
                    services.AddTransient<IInterfaceService, InterfaceService>();
                    services.AddTransient<MainViewModel>();
                    services.AddTransient<MainWindow>();
                })
                .Build();

            host.Start();

            host.Services.GetRequiredService<MainWindow>().Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                host?.StopAsync().GetAwaiter();
            }

            base.OnExit(e);
        }
    }
}
