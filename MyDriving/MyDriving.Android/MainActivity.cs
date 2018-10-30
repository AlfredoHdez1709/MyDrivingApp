using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using MyDriving.Droid.Fragments;
using Android.Support.V4.View;
using Android.Support.Design.Widget;
using MyDriving.Utils;
using Android.Runtime;
using System;
using System.Threading.Tasks;
//1 using HockeyApp;

namespace MyDriving.Droid
{
    //TODO: Descomentar
    /*[Activity(Label = "MyDriving", Icon = "@drawable/ic_launcher", Theme = "@style/MyTheme",
            ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
            ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : BaseActivity
    */
    [Activity(Label = "MyDriving", 
        Icon = "@drawable/ic_launcher", 
        Theme = "@style/MyTheme", 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, 
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;

        int oldPosition = -1;

        bool shouldClose;

        protected int LayoutResource => Resource.Layout.activity_main;

        protected async override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

#if !XTC
            //2 InitializeHockeyApp();
#endif
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            //Set hamburger items menu
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);

            //setup navigation view
            /*3 navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            //handle navigation
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);

                ListItemClicked(e.MenuItem.ItemId);

                
                SupportActionBar.Title = e.MenuItem.ItemId == Resource.Id.menu_profile
                    ? Settings.Current.UserFirstName
                    : e.MenuItem.TitleFormatted.ToString();
                    
                SupportActionBar.Title = e.MenuItem.TitleFormatted.ToString();

                drawerLayout.CloseDrawers();
            };
        */

            if (Intent.GetBooleanExtra("tracking", false))
            {
                ListItemClicked(Resource.Id.menu_current_trip);
                SupportActionBar.Title = "Current Trip";
                return;
            }

            global::Xamarin.Forms.Forms.Init(this, bundle);

            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, bundle);

            SetContentView(LayoutResource);

            //await MyDriving.Services.OBDDataProcessor.GetProcessor().Initialize(ViewModel.ViewModelBase.StoreManager)
            await MyDriving.Services.OBDDataProcessor.GetProcessor().Initialize();

            Android.Support.V4.App.Fragment fragment = null;
            fragment = FragmentCurrentTrip.NewInstance();


            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .Commit();


            //if first time you will want to go ahead and click first item.
            /*4
            if (bundle == null)
            {
                ListItemClicked(Resource.Id.menu_current_trip);
                SupportActionBar.Title = "Current Trip";
            }*/
        }

        void InitializeHockeyApp()
        {
            /*4
            if (string.IsNullOrWhiteSpace(Logger.HockeyAppAndroid))
                return;

            HockeyApp.CrashManager.Register(this, Logger.HockeyAppAndroid);
            HockeyApp.Metrics.MetricsManager.Register(this, Application, Logger.HockeyAppAndroid);
            HockeyApp.Metrics.MetricsManager.EnableUserMetrics();

            CheckForUpdates();
            */
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void CheckForUpdates()
        {
            // Remove this for store builds!
            //5 UpdateManager.Register(this, Logger.HockeyAppAndroid);
        }

        void UnregisterManagers()
        {
            //6 UpdateManager.Unregister();
        }

        protected override void OnPause()
        {
            base.OnPause();

            UnregisterManagers();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            UnregisterManagers();
        }


        void ListItemClicked(int itemId)
        {
            //this way we don't load twice, but you might want to modify this a bit.
            if (itemId == oldPosition)
                return;
            shouldClose = false;
            oldPosition = itemId;

            Android.Support.V4.App.Fragment fragment = null;
            switch (itemId)
            {
                case Resource.Id.menu_past_trips:
                    //7fragment = FragmentPastTrips.NewInstance();
                    break;
                case Resource.Id.menu_current_trip:
                    fragment = FragmentCurrentTrip.NewInstance();
                    break;
                case Resource.Id.menu_profile:
                    //8fragment = FragmentProfile.NewInstance();
                    break;
                case Resource.Id.menu_settings:
                    //9fragment = FragmentSettings.NewInstance();
                    break;
            }

            if (fragment != null)
                SupportFragmentManager.BeginTransaction()
                    .Replace(Resource.Id.content_frame, fragment)
                    .Commit();

            //10 navigationView.SetCheckedItem(itemId);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        protected override void OnStart()
        {
            base.OnStart();
            shouldClose = false;
        }

        public override void OnBackPressed()
        {
            if (drawerLayout.IsDrawerOpen((int)GravityFlags.Start))
            {
                drawerLayout.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                if (!shouldClose)
                {
                    Toast.MakeText(this, "Press back again to exit.", ToastLength.Short).Show();
                    shouldClose = true;
                    return;
                }
                base.OnBackPressed();
            }
        }
    }
}

