using App.Core.Devices.Driver.Protocol.ProtocolModel;
using App.Core.Devices.Driver.Protocol.ProtocolModel.Interfaces;
using App.Core.Devices.Driver.Protocol.ProtocolModel.Request;
using App.Core.Devices.Driver.Protocol.ProtocolModel.Response;
using App.Core.Devices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Devices.Driver.Protocol
{
    public class DeviceProtocolFactory
    {
        public static IDeviceProtocol<TReq, TResp> CreateProtocol<TReq, TResp>(string createKey) where TResp : IProtocolResponse where TReq : IProtocolRequest
        {
            IDeviceProtocol<TReq, TResp> protocol = null;

            //TODO 
            //--모델 구현 추가로 더 필요함. 현재 ModBusTCP RTU 모두같음
            switch (createKey)
            {
                case "MODBUSTCP"
                    protocol = (IDeviceProtocol<ModbusReadRequest, ModbusReadResponse>)(object)new ModbusTCP();
                    break;
                default:
                    throw new NotSupportedException($"is Not Key");
                    break;
            }
            //if (typeof(TReq) == typeof(ModbusReadRequest) && typeof(TResp) == typeof(ModbusReadResponse))
            //{
               
            //}
            //else if (typeof(TReq) == typeof(ModbusReadRequest) && typeof(TResp) == typeof(ModbusReadResponse)
            //{
            //    protocol = (IDeviceProtocol<TReq, TResp>)(object)new ModbusRTU();
            //}
            //else
            //    throw new NotSupportedException($"No mapping for {typeof(TReq).Name}/{typeof(TResp).Name}");

            return protocol;
        }
    }
}
