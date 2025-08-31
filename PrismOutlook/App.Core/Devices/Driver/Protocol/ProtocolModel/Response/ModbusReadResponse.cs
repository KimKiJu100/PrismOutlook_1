using App.Core.Devices.Driver.Protocol.ProtocolModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Devices.Driver.Protocol.ProtocolModel.Response
{
    internal class ModbusReadResponse : IProtocolResponse
    {
        public ushort[] Registers { get; init; } = Array.Empty<ushort>();
    }
}
