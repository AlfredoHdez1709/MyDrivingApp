using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MyDriving.Interfaces;
using MyDriving.Shared;
using MyDriving.Utils;
using MyDriving.UWP.Views;

namespace MyDriving.UWP
{
    //TODO: Corregir HockeyApp y otros
    sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;

            ViewModel.ViewModelBase.Init();
            //1 Microsoft.HockeyApp.HockeyClient.Current.Configure(Logger.HockeyAppUWP);
        }

        protected async override void OnLaunched(LaunchActivatedEventArgs e)
        {
            var shell = Window.Current.Content as SplitViewShell;

            if (shell == null)
            {
                Frame rootFrame = new Frame();
                rootFrame.NavigationFailed += OnNavigationFailed;

                Xamarin.Forms.Forms.Init(e);

                //Register platform specific implementations of shared interfaces
                //2 ServiceLocator.Instance.Add<IAuthentication, Authentication>();
                //3 ServiceLocator.Instance.Add<Utils.Interfaces.ILogger, PlatformLogger>();
                ServiceLocator.Instance.Add<IOBDDevice, OBDDevice>();
                Xamarin.Forms.DependencyService.Register<ObdLibUWP.ObdWrapper>();

                //4 if (Settings.Current.IsLoggedIn)
                {
                    //When the first screen of the app is launched after user has logged in, initialize the processor that manages connection to OBD Device and to the IOT Hub
                    await MyDriving.Services.OBDDataProcessor.GetProcessor().Initialize(ViewModel.ViewModelBase.StoreManager);
                    //await MyDriving.Services.OBDDataProcessor.GetProcessor().Initialize();

                    // Create the shell and set it to current trip
                    shell = new SplitViewShell(rootFrame);
                    shell.SetTitle("CURRENT TRIP");
                    shell.SetSelectedPage("CURRENT TRIP");
                    rootFrame.Navigate(typeof(CurrentTripView), e.Arguments);
                    Window.Current.Content = shell;
                }
/*6                else if (Settings.Current.FirstRun)
                {
                    rootFrame.Navigate(typeof(GetStarted1), e.Arguments);
                    Window.Current.Content = rootFrame;
                }
                else
                {
                    rootFrame.Navigate(typeof(LoginView), e.Arguments);
                    Window.Current.Content = rootFrame;
                }
*/            }

            Window.Current.Activate();
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        public static void SetTitle(string title)
        {
            var shell = Window.Current.Content as SplitViewShell;
            if (shell != null)
            {
                shell.SetTitle(title);
                shell.SetSelectedPage(title);
            }
        }
    }
}
