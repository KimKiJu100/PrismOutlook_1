using App.Core.Devices.Driver.Protocol.ProtocolModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Devices.Driver.Protocol.ProtocolModel.Request
{
    public class ModbusReadRequest : IProtocolRequest
    {
        public byte UnitId { get; init; }
        public ushort StartAddress { get; init; }
        public ushort Count { get; init; }
    }
}
