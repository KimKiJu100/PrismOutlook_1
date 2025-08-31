using App.Core.Devices.Abstract;
using App.Core.Devices.Driver.Protocol;
using App.Core.Devices.Driver.Protocol.ProtocolModel.Interfaces;
using App.Core.Devices.Driver.Protocol.ProtocolModel.Response;
using App.Core.Devices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core
{
    public abstract class Device : IDevice
    {
        private IDeviceChannel _channel;
        private IDeviceProtocol<IProtocolRequest, IProtocolResponse> _protocol;

        public Device()
        {
        }

        private void CreateDevice(IDriverParameter driverParameter)
        {
            _channel = DeviceFactory.CreateDeviceConnection(driverParameter);
            //TODO : 전략패턴으로 구현해야된다.
            _protocol = DeviceProtocolFactory.CreateProtocol<IProtocolRequest,IProtocolResponse>(driverParameter);
        }

        public void Open(IDriverParameter driverParameter)
        {
            if (_channel != null) return;
            CreateDevice(driverParameter);

            _channel.Connecntion(driverParameter);
        }
    }
}
