using App.Core.Devices.Driver.Concrete;
using App.Core.Devices.Driver.Parameter;
using App.Core.Devices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Devices.Abstract
{
    public class DeviceFactory
    {
        public static IDeviceChannel CreateDeviceConnection(IDriverParameter driverParameter)
        {
            IDeviceChannel ch = null;

            if (driverParameter is SerialParameter)
                ch = new SerialDriver();

            return ch;
        }

        public static IDeviceProtocol CreateDeviceProtocol(IDriverParameter driverParameter)
        {
            
        }
    }
}
