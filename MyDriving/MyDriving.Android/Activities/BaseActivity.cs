using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
//1 using MyDriving.Droid.Helpers;
using Plugin.Permissions;
using Android.Content.PM;
using Android.Transitions;

namespace MyDriving.Droid
{
    //TODO: Descomentar 9 lineas
    public abstract class BaseActivity : AppCompatActivity//2 , IAccelerometerListener
    {
        //3 AccelerometerManager accelerometerManager;
        bool canShowFeedback;
        public Toolbar Toolbar { get; set; }
        protected abstract int LayoutResource { get; }

        protected int ActionBarIcon
        {
            set { Toolbar.SetNavigationIcon(value); }
        }

        public void OnAccelerationChanged(float x, float y, float z)
        {
        }

        public void OnShake(float force)
        {
            if (!canShowFeedback)
                return;
            canShowFeedback = false;
            //4 HockeyApp.FeedbackManager.ShowFeedbackActivity(this);
        }

        protected override void OnCreate(Bundle bundle)
        {
            InitActivityTransitions();
            base.OnCreate(bundle);
            SetContentView(LayoutResource);
            Toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (Toolbar != null)
            {
                SetSupportActionBar(Toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(true);
            }

            //5 accelerometerManager = new AccelerometerManager(this, this);
            //6 accelerometerManager.Configure(40, 350);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        protected override void OnResume()
        {
            base.OnResume();
            canShowFeedback = true;
            /*7if (accelerometerManager.IsSupported)
                accelerometerManager.StartListening();
                */
        }

        void InitActivityTransitions()
        {
            if ((int)Build.VERSION.SdkInt >= 21)
            {
                var transition = new Slide();
                transition.ExcludeTarget(Android.Resource.Id.StatusBarBackground, true);
                Window.EnterTransition = transition;
                Window.ReturnTransition = transition;
                Window.RequestFeature(Android.Views.WindowFeatures.ContentTransitions);
                Window.RequestFeature(Android.Views.WindowFeatures.ActivityTransitions);
                Window.SharedElementEnterTransition = new ChangeBounds();
                Window.SharedElementReturnTransition = new ChangeBounds();
                Window.AllowEnterTransitionOverlap = true;
                Window.AllowReturnTransitionOverlap = true;
            }
        }

        protected override void OnStop()
        {
            base.OnStop();
            /*8
            if (accelerometerManager.IsListening)
                accelerometerManager.StopListening();*/
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            /*9
            if (accelerometerManager.IsListening)
                accelerometerManager.StopListening();*/
        }
    }
}