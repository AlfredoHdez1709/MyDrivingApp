using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDriving.Interfaces
{
    public interface IObdWrapper
    {
        Task<bool> Init(bool simulatormode = false);
        Dictionary<string, string> Read();
        Task<string> GetVIN();
        Task Disconnect();
    }
}