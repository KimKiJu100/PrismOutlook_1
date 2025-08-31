using App.Core.Devices.Driver.Protocol.ProtocolModel.Interfaces;
using App.Core.Devices.Driver.Protocol.ProtocolModel.Request;
using App.Core.Devices.Driver.Protocol.ProtocolModel.Response;
using App.Core.Devices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Devices.Driver.Protocol.ProtocolModel
{
    public class ModbusTCP : IDeviceProtocol<ModbusReadRequest, ModbusReadResponse>
    {
        public string Key => "ModbusTCP";

        public Type GetRequestType(){
            return typeof(ModbusReadRequest);
        }

        public Type GetTResponse(){
            return typeof(ModbusReadResponse);
        }
    }

    public class ModbusRTU : IDeviceProtocol<ModbusReadRequest, ModbusReadResponse>
    {
        public string Key => "ModbusRTU";
        public Type GetRequestType(){
            return typeof(ModbusReadRequest);
        }

        public Type GetTResponse(){
            return typeof(ModbusReadResponse);
        }
    }

    public class XGTProtocol : IDeviceProtocol<ModbusReadRequest, IProtocolResponse>
    {
        public string Key => "XGT_PROTOCOL";
        public Type GetRequestType()
        {
            throw new NotImplementedException();
        }

        public Type GetTResponse()
        {
            throw new NotImplementedException();
        }
    }
}
