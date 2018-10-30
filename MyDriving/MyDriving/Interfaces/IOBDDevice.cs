using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDriving.Interfaces
{
    public interface IOBDDevice
    {
        bool IsSimulated { get; }
        Task<bool> Initialize(bool 
            Mode = false);
        Dictionary<String, String> ReadData();
        Task Disconnect();
    }
}