using App.Core.Devices.Driver.Protocol.ProtocolModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Devices.Interfaces
{
    public interface IDeviceProtocol<TRequest,TResponse> where TResponse : IProtocolResponse 
    {
        public string Key { get; }
        public Type GetRequestType();
        public Type GetTResponse();
    }
}
