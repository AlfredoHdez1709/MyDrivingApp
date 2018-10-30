using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyDriving.Interfaces;
using Xamarin.Forms;

namespace MyDriving.Shared
{
    public class OBDDevice : IOBDDevice
    {
        readonly IObdWrapper obdWrapper = DependencyService.Get<IObdWrapper>();

        public bool IsSimulated { get; private set; }

        public async Task Disconnect()
        {
            await obdWrapper.Disconnect();
        }

        public async Task<bool> Initialize(bool simulatorMode = false)
        {
            IsSimulated = simulatorMode;
            return await obdWrapper.Init(simulatorMode);
        }

        public Dictionary<String, String> ReadData()
        {
            return obdWrapper.Read();
        }
    }
}