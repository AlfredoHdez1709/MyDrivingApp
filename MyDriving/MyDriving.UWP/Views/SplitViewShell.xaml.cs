using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using MyDriving.UWP.Controls;

namespace MyDriving.UWP.Views
{
    //TODO: Fix
    public sealed partial class SplitViewShell
    {
        SplitViewButtonContent selectedControl;

        public SplitViewShell(Frame frame)
        {
            InitializeComponent();
            MyDrivingSplitView.Content = frame;

            frame.Navigated += Frame_Navigated;

            Current.LabelText = "Current Trip";
            Current.DefaultImageSource =
                new BitmapImage(new Uri("ms-appx:///Assets/SplitView/current.png", UriKind.Absolute));
            Current.SelectedImageSource =
                new BitmapImage(new Uri("ms-appx:///Assets/SplitView/selected_current.png", UriKind.Absolute));

            PastTrips.LabelText = "Past Trips";
            PastTrips.DefaultImageSource =
                new BitmapImage(new Uri("ms-appx:///Assets/SplitView/pastTrips.png", UriKind.Absolute));
            PastTrips.SelectedImageSource =
                new BitmapImage(new Uri("ms-appx:///Assets/SplitView/selected_pastTrips.png", UriKind.Absolute));

            Profile.LabelText = "Profile";
            Profile.DefaultImageSource =
                new BitmapImage(new Uri("ms-appx:///Assets/SplitView/profile.png", UriKind.Absolute));
            Profile.SelectedImageSource =
                new BitmapImage(new Uri("ms-appx:///Assets/SplitView/selected_profile.png", UriKind.Absolute));

            Settings.LabelText = "Settings";
            Settings.DefaultImageSource =
                new BitmapImage(new Uri("ms-appx:///Assets/SplitView/settings.png", UriKind.Absolute));
            Settings.SelectedImageSource =
                new BitmapImage(new Uri("ms-appx:///Assets/SplitView/selected_settings.png", UriKind.Absolute));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MyDrivingSplitView.IsPaneOpen = !MyDrivingSplitView.IsPaneOpen;
            if (MyDrivingSplitView.IsPaneOpen)
            {
                double openPaneLength = MainGrid.ActualWidth * .6;
                if (openPaneLength > MyDrivingSplitView.OpenPaneLength && openPaneLength < 300)
                {
                    MyDrivingSplitView.OpenPaneLength = openPaneLength;
                    NewTripButton.Width = openPaneLength;
                    TripsButton.Width = openPaneLength;
                    ProfileButton.Width = openPaneLength;
                    SettingsButton.Width = openPaneLength;
                }
            }
        }


        private void TripsButton_Click(object sender, RoutedEventArgs e)
        {
            SelectControl(PastTrips);
            MyDrivingSplitView.IsPaneOpen = false;
            PageTitle.Text = "PAST TRIPS";
            //2 ((Frame)MyDrivingSplitView.Content).Navigate(typeof(PastTripsMenuView));
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            SelectControl(Profile);
            MyDrivingSplitView.IsPaneOpen = false;
            PageTitle.Text = "PROFILE";
            //3 ((Frame)MyDrivingSplitView.Content).Navigate(typeof(ProfileView));
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SelectControl(Settings);
            MyDrivingSplitView.IsPaneOpen = false;
            PageTitle.Text = "SETTINGS";
            //4 ((Frame)MyDrivingSplitView.Content).Navigate(typeof(SettingsView));
        }

        private void NewTripButton_Click(object sender, RoutedEventArgs e)
        {
            SelectControl(Current);
            MyDrivingSplitView.IsPaneOpen = false;
            PageTitle.Text = "CURRENT TRIP";
            ((Frame)MyDrivingSplitView.Content).Navigate(typeof(CurrentTripView));
        }


        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            MyDrivingSplitView.IsPaneOpen = false;
        }

        public void SelectControl(SplitViewButtonContent control)
        {
            selectedControl?.SetSelected(false);
            control.SetSelected(true);
            selectedControl = control;
        }

        public void SetTitle(string title)
        {
            PageTitle.Text = title;
        }

        public void SetSelectedPage(string page)
        {
            switch (page)
            {
                case "PAST TRIPS":
                    SelectControl(PastTrips);
                    break;
                case "PROFILE":
                    SelectControl(Profile);
                    break;
                case "SETTINGS":
                    SelectControl(Settings);
                    break;
                default:
                    SelectControl(Current);
                    break;
            }
        }
    }
}