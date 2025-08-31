using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Devices.Interfaces
{
    public interface IDeviceConnection
    {
        public bool IsConnected { get; }
        public bool Connecntion(IDriverParameter param);
    }
}
