using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDriving.Interfaces;
using Xamarin.Forms;

namespace MyDriving.Shared
{
    public class OBDDeviceSim : IOBDDevice
    {
        IObdWrapper obdWrapper = DependencyService.Get<IObdWrapper>();

        public async Task Disconnect()
        {
            await this.obdWrapper.Disconnect();
        }

        public async Task<bool> Initialize(bool simulatorMode = true)
        {
            return await this.obdWrapper.Init(true);
        }

        public bool IsSimulated => true;

        public Dictionary<string, string> ReadData()
        {
            return this.obdWrapper.Read();
        }
    }
}