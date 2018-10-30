using MyDriving.Utils;
using System;

namespace MyDriving.ViewModel
{
    //TODO: Descomentar después de agregar Settings
    public class TripSummaryViewModel : ViewModelBase
    {
        double fuelUsed;

        long hardAccelerations;


        long hardStops;

        double maxSpeed;

        double totalDistance;

        double totalTime;

        //1 public string FuelUnits => Settings.MetricUnits ? "L" : "gal.";
        public string FuelUnits => "gal.";

        //2 public double FuelConverted => Settings.MetricUnits ? FuelUsed / .264172 : FuelUsed;
        public double FuelConverted => FuelUsed;

        public string FuelDisplayNoUnits => FuelConverted.ToString("F");

        public string FuelDisplay => $"{FuelDisplayNoUnits} {FuelUnits}";

        //3 public string DistanceUnits => Settings.MetricDistance ? "km" : "miles";
        public string DistanceUnits => "miles";

        public string TotalDistanceDisplayNoUnits => DistanceConverted.ToString("F");

        public string TotalDistanceDisplay => $"{TotalDistanceDisplayNoUnits} {DistanceUnits}";

        //4 public double DistanceConverted => (Settings.Current.MetricDistance ? (TotalDistance * 1.60934) : TotalDistance);
        public double DistanceConverted => TotalDistance;

        //5 public string SpeedUnits => Settings.MetricDistance ? "km/h" : "mph";
        public string SpeedUnits => "mph";

        //6 public double MaxSpeedConverted => Settings.MetricDistance ? MaxSpeed : MaxSpeed * 0.621371;
        public double MaxSpeedConverted => MaxSpeed * 0.621371;

        public string MaxSpeedDisplayNoUnits => MaxSpeedConverted.ToString("F");

        public string MaxSpeedDisplay => $"{MaxSpeedDisplayNoUnits} {SpeedUnits}";

        public DateTime Date { get; set; }

        public string TotalTimeDisplay
        {
            get
            {
                var time = TimeSpan.FromSeconds(TotalTime);
                if (time.TotalMinutes < 1)
                    return $"{time.Seconds}s";

                if (time.TotalHours < 1)
                    return $"{time.Minutes}m {time.Seconds}s";

                return $"{(int)time.TotalHours}h {time.Minutes}m {time.Seconds}s";
            }
        }

        public double TotalDistance
        {
            get { return totalDistance; }
            set
            {
                if (!SetProperty(ref totalDistance, value))
                    return;

                OnPropertyChanged(nameof(DistanceUnits));
                OnPropertyChanged(nameof(TotalDistanceDisplay));
                OnPropertyChanged(nameof(TotalDistanceDisplayNoUnits));
                OnPropertyChanged(nameof(DistanceConverted));
            }
        }

        public double FuelUsed
        {
            get { return fuelUsed; }
            set
            {
                if (!SetProperty(ref fuelUsed, value))
                    return;

                OnPropertyChanged(nameof(FuelUnits));
                OnPropertyChanged(nameof(FuelDisplay));
                OnPropertyChanged(nameof(FuelDisplayNoUnits));
                OnPropertyChanged(nameof(FuelConverted));
            }
        }

        public double TotalTime
        {
            get { return totalTime; }
            set
            {
                if (!SetProperty(ref totalTime, value))
                    return;

                OnPropertyChanged(nameof(TotalTimeDisplay));
            }
        }

        public double MaxSpeed
        {
            get { return maxSpeed; }
            set
            {
                if (!SetProperty(ref maxSpeed, value))
                    return;

                OnPropertyChanged(nameof(SpeedUnits));
                OnPropertyChanged(nameof(MaxSpeedConverted));
                OnPropertyChanged(nameof(MaxSpeedDisplayNoUnits));
                OnPropertyChanged(nameof(MaxSpeedDisplay));
            }
        }

        public long HardStops
        {
            get { return hardStops; }
            set { SetProperty(ref hardStops, value); }
        }

        public long HardAccelerations
        {
            get { return hardAccelerations; }
            set { SetProperty(ref hardAccelerations, value); }
        }
    }
}