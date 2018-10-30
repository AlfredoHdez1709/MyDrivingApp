using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using MyDriving.Utils;

namespace MyDriving.Droid.Activities
{
    //TODO: Corregir Settings
    [Activity(Label = "MyDriving", Theme = "@style/SplashTheme", MainLauncher = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Intent newIntent;
            //1 if (Settings.Current.IsLoggedIn)
            {
                newIntent = new Intent(this, typeof(MainActivity));

                //When the first screen of the app is launched after user has logged in, initialize the processor that manages connection to OBD Device and to the IOT Hub
                //2 MyDriving.Services.OBDDataProcessor.GetProcessor().Initialize(ViewModel.ViewModelBase.StoreManager);
            }

            //3 else if (Settings.Current.FirstRun)
            {
#if XTC
                //4 newIntent = new Intent(this, typeof(LoginActivity));

#else
                //5 newIntent = new Intent(this, typeof(GettingStartedActivity));

#endif

#if !DEBUG
                Settings.Current.FirstRun = false;
#endif
            }
            //6 else newIntent = new Intent(this, typeof(LoginActivity));

            newIntent.AddFlags(ActivityFlags.ClearTop);
            newIntent.AddFlags(ActivityFlags.SingleTop);
            StartActivity(newIntent);
            Finish();
        }
    }
}